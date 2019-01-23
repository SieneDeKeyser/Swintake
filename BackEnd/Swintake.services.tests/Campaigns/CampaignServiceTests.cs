using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using NSubstitute;
using Swintake.domain;
using Swintake.domain.Campaigns;
using Swintake.infrastructure.Exceptions;
using Swintake.services.Campaigns;
using Xunit;

namespace Swintake.services.tests.Campaigns
{
    public class CampaignServiceTests
    {
        private readonly CampaignService _campaignService;
        private readonly IRepository<Campaign> _campaignRepository;

        public CampaignServiceTests()
        {
            _campaignRepository = Substitute.For<IRepository<Campaign>>();
            _campaignService = new CampaignService(_campaignRepository);
        }

        internal Campaign TestCampaign = new Campaign.CampaignBuilder()
            .WithId(Guid.NewGuid())
            .WithClient("ClientSwinTake")
            .WithClassStartDate(DateTime.Today)
            .WithStartDate(DateTime.Today)
            .WithComment("CommentSwinTake")
            .WithName("TestCampaignSwinTake")
            .WithStatus(CampaignStatus.Active).Build();

        internal Campaign TestCampaign1 = new Campaign.CampaignBuilder()
            .WithId(Guid.NewGuid())
            .WithClient("Client SwinTake")
            .WithClassStartDate(DateTime.Today)
            .WithStartDate(DateTime.Today)
            .WithComment("Comment SwinTake")
            .WithName("TestCampaign SwinTake")
            .WithStatus(CampaignStatus.Active).Build();

        [Fact]
        public void CreateCampaign_HappyPath()
        {
            //given
            Campaign createdCampaign = _campaignService.AddCampaign(TestCampaign);
            Assert.NotNull(createdCampaign);
            Assert.NotEqual(createdCampaign.Id, Guid.Empty);
        }

        [Fact]
        public void CreateCampaign_GivenCAmpaignThatIsNotValidForCreation_ThenThrowException()
        {
            Campaign testCampaign2 = CloneObject(TestCampaign);
            testCampaign2.Name = string.Empty;
            Exception ex = Assert.Throws<EntityNotValidException>(() => _campaignService.AddCampaign(testCampaign2));
            Assert.Contains("campaign", ex.Message);
        }

        [Fact]
        public void GivenMockDatabaseWith2Objects_GetAllCampaigns__ReturnListOfTwoObjects()
        {
            _campaignRepository.GetAll().Returns(new List<Campaign>() { TestCampaign, TestCampaign1 });

            var result = _campaignService.GetAllCampaigns().Count();

            Assert.Equal(2, result);
        }

        private T CloneObject<T>(T obj)
        {
            DataContractSerializer dcSer = new DataContractSerializer(obj.GetType());
            MemoryStream memoryStream = new MemoryStream();
            dcSer.WriteObject(memoryStream, obj);
            memoryStream.Position = 0;
            T newObject = (T)dcSer.ReadObject(memoryStream);
            return newObject;
        }
    }
}
