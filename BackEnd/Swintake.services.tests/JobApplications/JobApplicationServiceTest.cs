using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using NSubstitute;
using Swintake.domain.JobApplications;
using Swintake.domain;
using Swintake.services.JobApplications;
using Swintake.services.Candidates;
using Swintake.services.Campaigns;
using Swintake.domain.Candidates;
using static Swintake.domain.Campaigns.Campaign;
using Swintake.domain.Campaigns;
using Swintake.domain.JobApplications.SelectionSteps;
using Swintake.infrastructure.Exceptions;

namespace Swintake.services.tests.JobApplications
{
    public class JobApplicationServiceTest
    {
        private readonly JobApplicationService _jobApplicationService;
        private readonly IRepository<JobApplication> _jobApplicationRepository;
        private readonly ICandidateService _candidateService;
        private readonly ICampaignService _campaignService;

        public JobApplicationServiceTest()
        {
            _jobApplicationRepository = Substitute.For<IRepository<JobApplication>>();
            _candidateService = Substitute.For<ICandidateService>();
            _campaignService = Substitute.For<ICampaignService>();
            _jobApplicationService = new JobApplicationService(_jobApplicationRepository, _candidateService, _campaignService);
        }


        [Fact]
        public void GivenNewJobApplicationWithExistingCampaignIdAnCandidateId_whenAddJobApplication_ThenCallToJobApplicationRepository()
        {
            //Given
            var janneke = new CandidateBuilder()
                        .WithId(Guid.NewGuid())
                        .WithFirstName("Janneke")
                        .WithLastName("Janssens")
                        .WithEmail("janneke.janssens@gmail.com")
                        .WithPhoneNumber("0470000000")
                        .WithGitHubUsername("janneke")
                        .WithLinkedIn("janneke")
                        .Build();

            var testCampaign = new CampaignBuilder()
                       .WithId(Guid.NewGuid())
                       .WithName("testName")
                       .WithClient("testClient")
                       .WithStatus(CampaignStatus.Active)
                       .WithStartDate(DateTime.Today.AddDays(5))
                       .WithClassStartDate(DateTime.Today.AddDays(5))
                       .WithComment("testComment")
                       .Build();

            var newJobApplication = new JobApplicationBuilder()
                   .WithId(Guid.NewGuid())
                   .WithCandidateId(janneke.Id)
                   .WithCampaignId(testCampaign.Id)
                   .WithStatus(StatusJobApplication.Active)
                   .Build();

            _candidateService.GetCandidateById(newJobApplication.CandidateId.ToString()).Returns(janneke);
            _campaignService.GetCampaignByID(newJobApplication.CampaignId.ToString()).Returns(testCampaign);

            //When
            _jobApplicationService.AddJobApplication(newJobApplication);

            //Then
            _jobApplicationRepository.Received().Save(newJobApplication);
        }

        [Fact]
        public void GivenNewJobApplicationWithExistingCampaignIdAndNonCandidateId_whenAddJobApplication_ThenNoCallToJobApplicationRepositoryAndEntityNotFoundException()
        {
            //Given
            var janneke = new CandidateBuilder()
                        .WithId(Guid.NewGuid())
                        .WithFirstName("Janneke")
                        .WithLastName("Janssens")
                        .WithEmail("janneke.janssens@gmail.com")
                        .WithPhoneNumber("0470000000")
                        .WithGitHubUsername("janneke")
                        .WithLinkedIn("janneke")
                        .Build();

            var testCampaign = new CampaignBuilder()
                       .WithId(Guid.NewGuid())
                       .WithName("testName")
                       .WithClient("testClient")
                       .WithStatus(CampaignStatus.Active)
                       .WithStartDate(DateTime.Today.AddDays(5))
                       .WithClassStartDate(DateTime.Today.AddDays(5))
                       .WithComment("testComment")
                       .Build();

            var newJobApplication = new JobApplicationBuilder()
                   .WithId(Guid.NewGuid())
                   .WithCandidateId(Guid.NewGuid())
                   .WithCampaignId(testCampaign.Id)
                   .WithStatus(StatusJobApplication.Active)
                   .Build();

            _candidateService.GetCandidateById(newJobApplication.CandidateId.ToString()).Returns(ex => { throw new EntityNotFoundException("test info", "candidate", newJobApplication.CandidateId); });
            _campaignService.GetCampaignByID(newJobApplication.CampaignId.ToString()).Returns(testCampaign);

            //When
            Action act = () => _jobApplicationService.AddJobApplication(newJobApplication);

            //Then
            _jobApplicationRepository.DidNotReceive().Save(newJobApplication);
            Assert.Throws<EntityNotFoundException>(act);
        }

        [Fact]
        public void GivenNewJobApplicationWithNonExistingCampaignIdAndExistingCandidateId_whenAddJobApplication_ThenNoCallToJobApplicationRepositoryAndEntityNotFoundException()
        {
            //Given
            var janneke = new CandidateBuilder()
                        .WithId(Guid.NewGuid())
                        .WithFirstName("Janneke")
                        .WithLastName("Janssens")
                        .WithEmail("janneke.janssens@gmail.com")
                        .WithPhoneNumber("0470000000")
                        .WithGitHubUsername("janneke")
                        .WithLinkedIn("janneke")
                        .Build();

            var testCampaign = new CampaignBuilder()
                       .WithId(Guid.NewGuid())
                       .WithName("testName")
                       .WithClient("testClient")
                       .WithStatus(CampaignStatus.Active)
                       .WithStartDate(DateTime.Today.AddDays(5))
                       .WithClassStartDate(DateTime.Today.AddDays(5))
                       .WithComment("testComment")
                       .Build();

            var newJobApplication = new JobApplicationBuilder()
                   .WithId(Guid.NewGuid())
                   .WithCandidateId(Guid.NewGuid())
                   .WithCampaignId(testCampaign.Id)
                   .WithStatus(StatusJobApplication.Active)
                   .Build();

            _candidateService.GetCandidateById(newJobApplication.CandidateId.ToString()).Returns(janneke);
            _campaignService.GetCampaignByID(newJobApplication.CampaignId.ToString()).Returns(ex => { throw new EntityNotFoundException("test info", "campaign", newJobApplication.CampaignId); });

            //When
            Action act = () => _jobApplicationService.AddJobApplication(newJobApplication);

            //Then
            _jobApplicationRepository.DidNotReceive().Save(newJobApplication);
            Assert.Throws<EntityNotFoundException>(act);
        }

        [Fact]
        public void GivenJobApplication_whenUpdateFirstTime_ThenSelectionStepChangedToNextLevelAndListWillReturnCount_1()
        {
            //given
            var appId = Guid.NewGuid();
            var newJobApplication = new JobApplicationBuilder()
                .WithId(appId)
                .WithCandidateId(Guid.NewGuid())
                .WithCampaignId(Guid.NewGuid())
                .WithStatus(StatusJobApplication.Active)
                .Build();

            //When
            _jobApplicationRepository.Get(appId).Returns(newJobApplication);
            var updatedJobApplication = _jobApplicationService.GoToNextSelectionStepInSelectionProcess(appId.ToString());
            
            //Then
            Assert.Single(updatedJobApplication.SelectionSteps);
        }

        [Fact]
        public void GivenJobApplication_whenEndOfSelectionProcess_ThenCountWillNotChange()
        {
            //given
            var appId = Guid.NewGuid();
            var newJobApplication = new JobApplicationBuilder()
                .WithId(appId)
                .WithCandidateId(Guid.NewGuid())
                .WithCampaignId(Guid.NewGuid())
                .WithStatus(StatusJobApplication.Active)
                .Build();

            //When
            _jobApplicationRepository.Get(appId).Returns(newJobApplication);
            var updatedJobApplication = _jobApplicationService.GoToNextSelectionStepInSelectionProcess(appId.ToString());
            for (int i = 0; i < SelectionStep.CountofStepsInSelectionProcess + 1; i++)
            {
                _jobApplicationRepository.Get(appId).Returns(updatedJobApplication);
                updatedJobApplication = _jobApplicationService.GoToNextSelectionStepInSelectionProcess(appId.ToString());
            }

            //Then
            Assert.Equal(updatedJobApplication.SelectionSteps.Count,
                _jobApplicationService.GoToNextSelectionStepInSelectionProcess(appId.ToString()).SelectionSteps.Count); 

        }

        [Fact]
        public void GivenExistingJobApplication_WhenRejectJobApplication_ThenJobApplicationIsRemoved()
        {
            //Given
            var janneke = new CandidateBuilder()
                        .WithId(Guid.NewGuid())
                        .WithFirstName("Janneke")
                        .WithLastName("Janssens")
                        .WithEmail("janneke.janssens@gmail.com")
                        .WithPhoneNumber("0470000000")
                        .WithGitHubUsername("janneke")
                        .WithLinkedIn("janneke")
                        .Build();

            var testCampaign = new CampaignBuilder()
                       .WithId(Guid.NewGuid())
                       .WithName("testName")
                       .WithClient("testClient")
                       .WithStatus(CampaignStatus.Active)
                       .WithStartDate(DateTime.Today.AddDays(5))
                       .WithClassStartDate(DateTime.Today.AddDays(5))
                       .WithComment("testComment")
                       .Build();

            var newJobApplication = new JobApplicationBuilder()
                   .WithId(Guid.NewGuid())
                   .WithCandidateId(janneke.Id)
                   .WithCampaignId(testCampaign.Id)
                   .WithStatus(StatusJobApplication.Active)
                   .Build();

            _jobApplicationRepository.Get(newJobApplication.Id).Returns(newJobApplication);

            //When
           var updatedJobapplication =  _jobApplicationService.RejectJobApplication(newJobApplication.Id.ToString());

            //Then
            Assert.Equal(StatusJobApplication.Rejected, updatedJobapplication.Status);
        }

        [Fact]
        public void GivenDatabaseWith2JobApp_GetAllJobApplications__ReturnListOfTwoJobApplications()
        {
            _jobApplicationRepository.GetAll().Returns(new List<JobApplication>()
                    { new JobApplicationBuilder().Build(), new JobApplicationBuilder().Build() });
            Assert.Equal(2, _jobApplicationService.GetJobApplications().Count());
        }
    }
}
