using Microsoft.EntityFrameworkCore;
using Swintake.domain.Campaigns;
using Swintake.domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using static Swintake.domain.Campaigns.Campaign;

namespace Swintake.domain.tests.Campaigns
{
    public class CampaignRepositoryTests
    {
        [Fact]
        public void GivenANewCampaign_WhenSaveNewCampaign_ThenNewCampaignIsSaved()
        {
            //given 
            var options = new DbContextOptionsBuilder<SwintakeContext>()
            .UseInMemoryDatabase("swintake" + Guid.NewGuid().ToString("n"))
            .Options;

            using (var context = new SwintakeContext(options))
            {
                var testCampaign = new CampaignBuilder()
                        .WithId(Guid.NewGuid())
                        .WithName("testName")
                        .WithClient("testClient")
                        .WithStatus(CampaignStatus.Active)
                        .WithStartDate(DateTime.Today.AddDays(5))
                        .WithClassStartDate(DateTime.Today.AddDays(5))
                        .WithComment("testComment")
                        .Build();

                IRepository<Campaign> campaignRepository = new CampaignRepository(context);

                //when
               campaignRepository.Save(testCampaign);

                //then
                var foundCampaign = context.Campaigns.SingleOrDefault(camp => camp.Id == testCampaign.Id);
                Assert.Equal(testCampaign.Name, foundCampaign.Name);
            }
        }
    }
}
