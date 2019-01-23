using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Swintake.api.Helpers.Users;
using Swintake.domain.Data;
using Swintake.domain.Users;
using Swintake.services.Users.Security;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Swintake.Integration.tests
{
    public class UsersIntegrationTests
    {

        [Fact]
        public async Task GivenExistingUser_WhenAuthenticate_ThenReturnOkWithJwtSecurityTokenRawData()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<TestStartup>()
                .UseConfiguration(new ConfigurationBuilder()
                    .AddUserSecrets("ecafb124-3b88-4041-ac3d-6bf9172b7efa")
                    .AddEnvironmentVariables()
                    .Build()));

            using (server)
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

                var userDTO = new UserDTO { Email = "user@switchfully.com", Password = "ILoveNiels" };

                var content = JsonConvert.SerializeObject(userDTO);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("api/users/authenticate", stringContent);
                //var responseString = await response.Content.ReadAsStringAsync();

                // The returned token is of format plain/text not of json.
                // var test = JsonConvert.DeserializeObject(responseString);

                Assert.True(response.IsSuccessStatusCode);
            }
        }
    }
}
