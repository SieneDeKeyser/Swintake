using Swintake.domain.Campaigns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swintake.api.Helpers.Campaigns
{
    public class CampaignDto
    {
        // fields
        public string Id { get; set; } 
        public string Name { get; set; }
        public string Client { get; set; }
        public CampaignStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ClassStartDate { get; set; }
        public string Comment { get; set; }
    }
}
