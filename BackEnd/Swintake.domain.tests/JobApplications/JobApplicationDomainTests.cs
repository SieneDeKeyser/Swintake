using System;
using System.Collections.Generic;
using System.Text;
using Swintake.domain.Campaigns;
using Swintake.domain.Candidates;
using Swintake.domain.JobApplications;
using Swintake.domain.JobApplications.SelectionSteps;
using Xunit;

namespace Swintake.domain.tests.JobApplications
{
    public class JobApplicationDomainTests
    {
        [Fact]
        public void GivenJobApplication_WhenCurrentSelectionIsnull_ThenFirstSelectionIsSetToCVScreening()
        {
        var newJobApplication = new JobApplicationBuilder()
            .WithId(Guid.NewGuid())
            .WithCandidateId(Guid.NewGuid())
            .WithCampaignId(Guid.NewGuid())
            .WithStatus(StatusJobApplication.Active)
            .Build();

            var selectionStep = new CvScreening();
            newJobApplication.GotoNextSelectionStep();
            Assert.Equal(selectionStep.Description, newJobApplication.CurrentSelectionStep.Description);
        }

        [Fact]
        public void GivenJobApplication_WhenLastSelectionStepFilledIn_ThenCurrentWillStayUnChanged()
        {
            var newJobApplication = new JobApplicationBuilder()
                .WithId(Guid.NewGuid())
                .WithCandidateId(Guid.NewGuid())
                .WithCampaignId(Guid.NewGuid())
                .WithStatus(StatusJobApplication.Active)
                .Build();

            var selectionStep = new FinalDecision();
            for (int i = 0; i < SelectionStep.CountofStepsInSelectionProcess+1; i++)
            {
                newJobApplication.GotoNextSelectionStep();
            }
            
            Assert.Equal(selectionStep.Description, newJobApplication.CurrentSelectionStep.Description);
            newJobApplication.GotoNextSelectionStep();
            Assert.Equal(selectionStep.Description, newJobApplication.CurrentSelectionStep.Description);
        }
    }
}
