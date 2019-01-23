using Swintake.api.Helpers.JobApplications;
using Swintake.domain.JobApplications;
using System;
using System.Collections.Generic;
using System.Text;
using Swintake.api.Helpers.Campaigns;
using Swintake.api.Helpers.Candidates;
using Xunit;

namespace Swintake.api.tests
{
    public class JobApplicationMapperTest
    {
        private readonly JobApplicationMapper _jobApplicationMapper;
        public JobApplicationMapperTest()
        {
            _jobApplicationMapper = new JobApplicationMapper(new CampaignMapper(), new CandidateMapper());
        }
        [Fact]
        public void GivenJobApplicationDto_WhenMapTonewDomain_ThenStatusIsActiveAndIdGuidIsCreated()
        {
            //Given
            var newJobApplicationDto = new CreateJobApplicationDto(

                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString()
            );

            //When
            var newJobApplication = _jobApplicationMapper.ToNewDomain(newJobApplicationDto);

            //Then
            Assert.IsType<JobApplication>(newJobApplication);
            Assert.Equal(StatusJobApplication.Active, newJobApplication.Status);
            Assert.IsType<Guid>(newJobApplication.Id);
        }
    }
}
