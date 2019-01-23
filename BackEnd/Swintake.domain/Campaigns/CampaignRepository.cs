using Swintake.domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Swintake.domain.Campaigns
{
    public class CampaignRepository : IRepository<Campaign>
    {
        private readonly SwintakeContext _context;

        public CampaignRepository(SwintakeContext context)
        {
            _context = context;
        }

        public Campaign Get(Guid entityId)
        {
            return _context.Campaigns.SingleOrDefault(campaign => campaign.Id == entityId);
        }

        public IList<Campaign> GetAll()
        {
            return _context.Campaigns.AsNoTracking().ToList();
        }

        public Campaign Save(Campaign campaign)
        {
            _context.Campaigns.Add(campaign); 
            _context.SaveChanges();
            return campaign;
        }

        public Campaign Update(Campaign entity)
        {
            throw new NotImplementedException();
        }
    }
}
