using Swintake.domain.JobApplications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Swintake.api.Helpers.Campaigns;
using Swintake.api.Helpers.Candidates;
using Swintake.domain.Campaigns;
using Swintake.domain.Candidates;
using Swintake.domain.JobApplications.SelectionSteps;

namespace Swintake.api.Helpers.JobApplications
{
    public class JobApplicationDto
    {
        public string Id { get; set; }
        public string CandidateId { get; set; }
        public CandidateDto Candidate { get; set; }

        public string CampaignId { get; set; }
        public CampaignDto Campaign { get; set; }
        public string Status { get; set; }
        public List<SelectionStepDto> SelectionSteps { get; set; }
        public SelectionStepDto CurrentSelectionStep { get; set; }
       
    }

    public class SelectionStepDto
    {
        public Guid JobApplicationId { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }

    }
}
