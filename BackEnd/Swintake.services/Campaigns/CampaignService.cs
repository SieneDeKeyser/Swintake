using Swintake.domain;
using Swintake.domain.Campaigns;
using Swintake.infrastructure.Exceptions;
using System;
using System.Collections.Generic;

namespace Swintake.services.Campaigns
{
    public class CampaignService : ICampaignService
    {
        private readonly IRepository<Campaign> _campaignRepository;

        public CampaignService(IRepository<Campaign> campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        public Campaign AddCampaign(Campaign campaign)
        {
            if (campaign == null)
            {
                throw new EntityNotValidException("add campaign", campaign);
            }

            if (Campaign.IsNotValidForCreation(campaign))
            {
                throw new EntityNotValidException("add campaign", campaign);
            }
            else
            {
                _campaignRepository.Save(campaign);
                return campaign;
            }
        }

        public IEnumerable<Campaign> GetAllCampaigns()
        {
            return _campaignRepository.GetAll();
        }

        public Campaign GetCampaignByID(string id)
        {
            var campaign = _campaignRepository.Get(new Guid(id));
            if (campaign == null)
            {
                throw new EntityNotFoundException("get campaign", "campaign", new Guid(id));
            }
            return campaign;
        }
    }
}
