using Swintake.domain.Campaigns;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.services.Campaigns
{
    public interface ICampaignService
    {
        Campaign AddCampaign(Campaign campaign);
        IEnumerable<Campaign> GetAllCampaigns();
        Campaign GetCampaignByID(string id);
    }
}
