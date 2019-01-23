using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using NSubstitute;
using SecuredWebApi.Services;
using Swintake.api.Controllers;
using Swintake.api.Helpers.Users;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Swintake.services.Users.Security;
using SecuredWebApi.Services.Security;
using Microsoft.Extensions.Options;
using Swintake.domain.Users;
using Swintake.services.Users;

namespace Swintake.api.tests.Users
{
    public class UsersControllerTests
    {
        private readonly IUserAuthenticationService _userAuthService;
        private readonly UsersController _usersController;
        

        public UsersControllerTests()
        {
            _userAuthService = Substitute.For<IUserAuthenticationService>();
            _usersController = new UsersController(_userAuthService, new UserMapper());
        }

        [Fact]
        public void GivenExistingUserDTO_WhenAuthenticate_ThenReturnOk()
        {
            //given
            UserDTO userDTO = new UserDTO { Email = "user@switchfully.com", Password = "ILoveReinout" };
            _userAuthService.Authenticate(userDTO.Email, userDTO.Password).Returns(new JwtSecurityToken());

            //when
            OkObjectResult returnValue = (OkObjectResult) _usersController.Authenticate(userDTO).Result;

            //then
            Assert.Equal(200, returnValue.StatusCode);
        }

        [Fact]
        public void GivenNonExistingUserDTO_WhenAuthenticate_ThenReturnBadRequest()
        {
            //given
            UserDTO userDTO = new UserDTO { Email = "user@switchfully.com", Password = "ILoveReinout" };
            UserDTO otherUserDTO = new UserDTO { Email = "user1@switchfully.com", Password = "ILoveReinout1" };
            _userAuthService.Authenticate(userDTO.Email, userDTO.Password).Returns(new JwtSecurityToken());

            //when
            BadRequestObjectResult returnValue = (BadRequestObjectResult) _usersController.Authenticate(otherUserDTO).Result;

            //then
            Assert.Equal(400, returnValue.StatusCode);
        }
    }
}
