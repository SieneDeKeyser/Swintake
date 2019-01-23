using Swintake.domain.Campaigns;
using Swintake.infrastructure.Mappers;
using System;
using System.Collections.Generic;

namespace Swintake.api.Helpers.Campaigns
{
    public class CampaignMapper : Mapper<CampaignDto, Campaign>
    {
        public override Campaign ToDomain(CampaignDto dtoObject)
        {
            return Campaign.CampaignBuilder.NewCampaign()
                .WithId(new Guid(dtoObject.Id))
                .WithName(dtoObject.Name)
                .WithClient(dtoObject.Client)
                .WithStatus(dtoObject.Status)
                .WithStartDate(dtoObject.StartDate)
                .WithClassStartDate(dtoObject.ClassStartDate)
                .WithComment(dtoObject.Comment)
                .Build();
        }

        public virtual Campaign ToNewDomain(CreateCampaignDto createCampaignDto)
        {
            return Campaign.CampaignBuilder.NewCampaign()
                .WithId(Guid.NewGuid())
                .WithName(createCampaignDto.Name)
                .WithClient(createCampaignDto.Client)
                .WithStatus(CampaignStatus.Active)
                .WithStartDate(createCampaignDto.StartDate)
                .WithClassStartDate(createCampaignDto.ClassStartDate)
                .WithComment(createCampaignDto.Comment)
                .Build();
        }

        public override CampaignDto ToDto(Campaign domainObject)
        {
            return new CampaignDto
            {
                Id = domainObject.Id.ToString(),
                Name = domainObject.Name,
                Client = domainObject.Client,
                Status = domainObject.Status,
                StartDate = domainObject.StartDate,
                ClassStartDate = domainObject.ClassStartDate,
                Comment = domainObject.Comment
            };
        }

        public List<CampaignDto> ToDtoList(IEnumerable<Campaign> campaigns)
        {
            List<CampaignDto> campaignDtos = new List<CampaignDto>();
            foreach (Campaign campaign in campaigns)
            {
                CampaignDto campaignDto = ToDto(campaign);
                campaignDtos.Add(campaignDto);
            }

            return campaignDtos;
        }
    }
}
