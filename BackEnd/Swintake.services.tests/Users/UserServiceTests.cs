using Swintake.domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using NSubstitute;
using SecuredWebApi.Services;
using Swintake.services.Users.Security;
using SecuredWebApi.Services.Security;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace Swintake.services.tests.Users
{
    public class UserServiceTests
    {
        private readonly IUserRepository _userRepository;
        private readonly Hasher _hasher;
        private readonly Salter _salter;
        private readonly UserAuthenticationService _userAuthService;
        private readonly IOptions<Secrets> _options;
        private Secrets _secrets;

        public UserServiceTests()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _hasher = new Hasher();
            _salter = new Salter();
            _options = Substitute.For<IOptions<Secrets>>();
            _secrets = new Secrets { SuperStrongPassword = "lalalalalalalalalalalalalaa" };
            _options.Value.Returns(_secrets);

            _userAuthService = new UserAuthenticationService(_userRepository, _hasher, _salter, _options);
        }

        [Fact]
        public void GivenValidEmailAndPassword_WhenAuthenticate_ThenReturnTypeIsJwtSecurityToken()
        {
            //given
            var user = new UserBuilder()
                       .WithEmail("user@switchfully.com")
                       .WithFirstName("User")
                       .WithUserSecurity(new UserSecurity("WO8nNwTcrxigARQfBn4nYRh8X16ExDQJ8jNuECJT8fE=", "F1e3n6zNR75LhUd5K73T/g=="))
                       .Build();
            _userRepository.FindByEmail(user.Email).Returns(user);

            //when
            var test = _userAuthService.Authenticate("user@switchfully.com", "ILoveNiels");

            //then
            Assert.Equal(typeof(JwtSecurityToken), test.GetType());
        }

        [Fact]
        public void GivenInvalidEmailAndPassword_WhenAuthenticate_ThenReturnsNull()
        {
            //given
            var user = new UserBuilder()
                       .WithEmail("user@switchfully.com")
                       .WithFirstName("User")
                       .WithUserSecurity(new UserSecurity("WO8nNwTcrxigARQfBn4nYRh8X16ExDQJ8jNuECJT8fE=", "F1e3n6zNR75LhUd5K73T/g=="))
                       .Build();

            _userRepository.FindByEmail("user@switchfully.com").Returns(user);

            //when
            var test = _userAuthService.Authenticate("user@switchfully.com", "ILoveNiels1");

            //then
            Assert.Null(test);
        }
    }
}
