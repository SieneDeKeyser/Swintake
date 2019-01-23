using Microsoft.EntityFrameworkCore;
using Swintake.domain.Data;
using Swintake.domain.JobApplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Swintake.domain.tests.JobApplications
{
    public class JobApplicationRepositoryTest
    {
        private readonly DbContextOptions<SwintakeContext> _options;
        private JobApplicationRepository _jobApplicationRepository;

        public JobApplicationRepositoryTest()
        {
            //given 
            _options = new DbContextOptionsBuilder<SwintakeContext>()
                .UseInMemoryDatabase("swintake" + Guid.NewGuid().ToString("n"))
                .Options;

        }

        [Fact]
        public void GivenNewJobapplication_WhenSavingNewJobapplication_ThenJobapplicationIsSaved()
        {
            using (var context = new SwintakeContext(_options))
            {
                //Given
                var newJobApplication = new JobApplicationBuilder()
                    .WithId(Guid.NewGuid())
                    .WithCandidateId(Guid.NewGuid())
                    .WithCampaignId(Guid.NewGuid())
                    .WithStatus(StatusJobApplication.Active)
                    .Build();

                _jobApplicationRepository = new JobApplicationRepository(context);

                //When
                _jobApplicationRepository.Save(newJobApplication);

                //Then
                Assert.Contains(newJobApplication, context.JobApplications);
            }
        }

        [Fact]
        public void GivenJobapplication_WhenUpdate_ThenUpdateJobApplicationInContext()
        {
            using (var context = new SwintakeContext(_options))
            {

                var newJobApplication = new JobApplicationBuilder()
                    .WithId(Guid.NewGuid())
                    .WithCandidateId(Guid.NewGuid())
                    .WithCampaignId(Guid.NewGuid())
                    .WithStatus(StatusJobApplication.Active)
                    .Build();

                _jobApplicationRepository = new JobApplicationRepository(context);
                _jobApplicationRepository.Save(newJobApplication);

                newJobApplication.Status = StatusJobApplication.Hired;
                _jobApplicationRepository.Update(newJobApplication);

                var jobapplication =
                    context.JobApplications.SingleOrDefault(jobapp => jobapp.Id == newJobApplication.Id);

                Assert.Equal(StatusJobApplication.Hired, jobapplication.Status);
            }
        }

        [Fact]
        public void GivenExistingJobApplication_WhenRejectingJobApplication_ThenJobApplicationIsRemoved()
        {
            using (var context = new SwintakeContext(_options))
            {
                //Given
                var newJobApplication = new JobApplicationBuilder()
                    .WithId(Guid.NewGuid())
                    .WithCandidateId(Guid.NewGuid())
                    .WithCampaignId(Guid.NewGuid())
                    .WithStatus(StatusJobApplication.Active)
                    .Build();

                _jobApplicationRepository = new JobApplicationRepository(context);
                _jobApplicationRepository.Save(newJobApplication);

                //When
                newJobApplication.SetNewStatus(StatusJobApplication.Rejected);

                //then
                Assert.Equal(StatusJobApplication.Rejected, newJobApplication.Status);
            }
        }
    }
}
