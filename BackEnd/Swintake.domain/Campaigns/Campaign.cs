using Swintake.infrastructure.builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace Swintake.domain.Campaigns
{
    public class Campaign : Entity
    {
        // fields
        [MaxLength(60)]
        public string Name { get; set; }
        [MaxLength(60)]
        public string Client { get; set; }
        public CampaignStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ClassStartDate { get; set; }
        [MaxLength(500)]
        public string Comment { get; set; }

        private Campaign() : base(Guid.Empty) { }

        public Campaign(CampaignBuilder campaignBuilder) : base(campaignBuilder.Id)
        {
            this.Name = campaignBuilder.Name;
            this.Client = campaignBuilder.Client;
            this.Status = campaignBuilder.Status;
            this.StartDate = campaignBuilder.StartDate;
            this.ClassStartDate = campaignBuilder.ClassStartDate;
            this.Comment = campaignBuilder.Comment;
        }

        public static bool IsNotValidForCreation(Campaign campaign)
        {
            return (campaign.Id == null
                || campaign.Id == Guid.Empty
                || string.IsNullOrWhiteSpace(campaign.Name)
                || string.IsNullOrWhiteSpace(campaign.Client)
                || campaign.Status != CampaignStatus.Active
                || campaign.ClassStartDate < campaign.StartDate);
        }

        public class CampaignBuilder : Builder<Campaign>
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Client { get; set; }
            public CampaignStatus Status { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime ClassStartDate { get; set; }
            public string Comment { get; set; }

            public static CampaignBuilder NewCampaign()
            {
                return new CampaignBuilder();
            }

            public CampaignBuilder WithId(Guid id)
            {
                Id = id;
                return this;
            }

            public CampaignBuilder WithName(string name)
            {
                Name = name;
                return this;
            }

            public CampaignBuilder WithClient(string client)
            {
                Client = client;
                return this;
            }

            public CampaignBuilder WithStatus(CampaignStatus campaignStatus)
            {
                Status = campaignStatus;
                return this;
            }

            public CampaignBuilder WithStartDate(DateTime startDate)
            {
                StartDate = startDate;
                return this;
            }

            public CampaignBuilder WithClassStartDate(DateTime classStartDate)
            {
                ClassStartDate = classStartDate;
                return this;
            }

            public CampaignBuilder WithComment(string comment)
            {
                Comment = comment;
                return this;
            }

            public override Campaign Build()
            {
                return new Campaign(this);
            }

        }

    }
}
