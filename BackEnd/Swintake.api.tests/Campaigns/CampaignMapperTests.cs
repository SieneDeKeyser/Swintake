using Swintake.api.Helpers.Campaigns;
using Swintake.domain.Campaigns;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static Swintake.domain.Campaigns.Campaign;

namespace Swintake.api.tests.Campaigns
{
    public class CampaignMapperTests
    {
        [Fact]
        public void GivenACreatedCampaignDto_WhenToNewDomain_ThenReturnCampaignObjectWithIdGuidAndStatusActive()
        {
            //given
            var newDTO = new CreateCampaignDto()
            {
                Name = "testCampaign",
                Client = "testClient",
                ClassStartDate = DateTime.Today.AddDays(5),
                StartDate = DateTime.Today.AddDays(5),
                Comment = "testComment"
            };

            var campaignMapper = new CampaignMapper();

            //when
            var newDomain = campaignMapper.ToNewDomain(newDTO);

            //then
            Assert.IsType<Guid>(newDomain.Id);
            Assert.Equal(CampaignStatus.Active, newDomain.Status);
        }

        [Fact]
        public void GivenACampaign_WhenToDto_ThenReturnCampaignDtoObjectWithSameProperties()
        {
            //given
            var campaign = new CampaignBuilder()
                                .WithId(Guid.NewGuid())
                                .WithName("testName")
                                .WithClient("testClient")
                                .WithStatus(CampaignStatus.Active)
                                .WithStartDate(DateTime.Today.AddDays(5))
                                .WithClassStartDate(DateTime.Today.AddDays(5))
                                .WithComment("testComment")
                                .Build();

            var campaignMapper = new CampaignMapper();

            //when
            var newDto = campaignMapper.ToDto(campaign);

            //then
            Assert.Equal(campaign.Id.ToString(), newDto.Id);
            Assert.Equal(campaign.Name, newDto.Name);
            Assert.Equal(campaign.Client, newDto.Client);
            Assert.Equal(campaign.Status, newDto.Status);
            Assert.Equal(campaign.StartDate, newDto.StartDate);
            Assert.Equal(campaign.ClassStartDate, newDto.ClassStartDate);
            Assert.Equal(campaign.Comment, newDto.Comment);
        }

    }
}
