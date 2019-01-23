using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swintake.api.Helpers.JobApplications
{
    public class CreateJobApplicationDto
    {
        public string CandidateId { get; set; }
        public string CampaignId { get; set; }

        public CreateJobApplicationDto(string candidateId, string campaignId)
        {
            CandidateId = candidateId;
            CampaignId = campaignId;
        }
    }
}
