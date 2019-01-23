using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Swintake.domain.Data;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using System;
using Swintake.api.Helpers.Campaigns;
using System.Net.Http.Headers;
using Swintake.domain.Users;
using Swintake.api.Helpers.Users;

namespace Swintake.Integration.tests.Campaigns
{
    public class CampaignsIntegrationTests
    {
        private async Task<HttpClient> InitClient(TestServer server)
        {
            var client = server.CreateClient();
            var context = server.Host.Services.GetService<SwintakeContext>();

            var user = new UserBuilder()
                    .WithEmail("user@switchfully.com")
                    .WithFirstName("User")
                    .WithUserSecurity(new UserSecurity("WO8nNwTcrxigARQfBn4nYRh8X16ExDQJ8jNuECJT8fE=", "F1e3n6zNR75LhUd5K73T/g=="))
                    .Build();

            context.Users.Add(user);
            context.SaveChanges();

            var userDto = new UserDTO { Email = "user@switchfully.com", Password = "ILoveNiels" };

            var contentUser = JsonConvert.SerializeObject(userDto);
            var stringContentUser = new StringContent(contentUser, Encoding.UTF8, "application/json");

            var responseToken = await client.PostAsync("api/users/authenticate", stringContentUser);
            var responseStringToken = await responseToken.Content.ReadAsStringAsync();
            var responseBearer1 = responseStringToken.Substring(1);
            var responseBearer2 = responseBearer1.Substring(0, responseBearer1.Length - 1);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + responseBearer2);
            return client;
        }


        [Fact]
        public async Task GivenNewCampaignJson_WhenCreatingNewCampaign_ThenCampaignObjectIsSavedAndReturned()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<TestStartup>()
                .UseConfiguration(new ConfigurationBuilder()
                    .AddUserSecrets("ecafb124-3b88-4041-ac3d-6bf9172b7efa")
                    .AddEnvironmentVariables()
                    .Build()));

            using (server)
            {
                var client = await InitClient(server);


                var newDTOCreated = new CreateCampaignDto()
                {
                    Name = "testCampaign",
                    Client = "testClient",
                    ClassStartDate = DateTime.Today.AddDays(5),
                    StartDate = DateTime.Today.AddDays(5),
                    Comment = "testComment"
                };

                var content = JsonConvert.SerializeObject(newDTOCreated);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("api/campaigns", stringContent);
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                var createdCampaign = JsonConvert.DeserializeObject<CampaignDto>(responseString);

                Assert.Equal("Created", response.StatusCode.ToString());
            }
        }

        [Fact]
        public async Task GivenNewCampaignJsonWithoutName_WhenCreatingNewCampaign_ThenReturnBadRequest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<TestStartup>()
                .UseConfiguration(new ConfigurationBuilder()
                    .AddUserSecrets("ecafb124-3b88-4041-ac3d-6bf9172b7efa")
                    .AddEnvironmentVariables()
                    .Build()));

            using (server)
            {
                var client = await InitClient(server);
 

                var newDTOCreated = new CreateCampaignDto()
                {
                    // Name = "testCampaign",
                    Client = "testClient",
                    ClassStartDate = DateTime.Today.AddDays(5),
                    StartDate = DateTime.Today.AddDays(5),
                    Comment = "testComment"
                };

                var content = JsonConvert.SerializeObject(newDTOCreated);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("api/campaigns", stringContent);
                var responseString = await response.Content.ReadAsStringAsync();

                Assert.Equal("BadRequest", response.StatusCode.ToString());
            }
        }

        [Fact]
        public async Task GivenHappyPath_WhenGetAllCampaigns_ThenCampaignsAreReturned()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<TestStartup>()
                .UseConfiguration(new ConfigurationBuilder()
                    .AddUserSecrets("ecafb124-3b88-4041-ac3d-6bf9172b7efa")
                    .AddEnvironmentVariables()
                    .Build()));

            using (server)
            {
                var client = await InitClient(server);
                var newDTOCreated = new CreateCampaignDto()
                {
                    Name = "testCampaign",
                    Client = "testClient",
                    ClassStartDate = DateTime.Today.AddDays(5),
                    StartDate = DateTime.Today.AddDays(5),
                    Comment = "testComment"
                };

                var content = JsonConvert.SerializeObject(newDTOCreated);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

                var response = await client.GetAsync("api/campaigns");
                response.EnsureSuccessStatusCode();

                Assert.Equal("OK", response.StatusCode.ToString());
            }
        }
    }
}
