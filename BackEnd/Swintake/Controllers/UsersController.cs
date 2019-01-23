using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swintake.api.Helpers.Users;
using Swintake.services.Users;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace Swintake.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly IUserAuthenticationService _userAuthService;
        private readonly UserMapper _userMapper;

        public UsersController(IUserAuthenticationService userAuthService, UserMapper userMapper)
        {
            _userAuthService = userAuthService;
            _userMapper = userMapper;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public ActionResult<JwtSecurityToken> Authenticate([FromBody] UserDTO userDTO)
        {
            var securityToken = _userAuthService.Authenticate(userDTO.Email, userDTO.Password);

            if (securityToken != null)
            {
                var test = JsonConvert.SerializeObject(securityToken.RawData);
                return Ok(test);
            }

            return BadRequest("Email or Password incorrect!");
        }

        [HttpGet("current")]
        [Authorize]
        public ActionResult<UserReplyDTO> GetCurrentUser()
        {
            var authenticatedUser = _userAuthService.GetCurrentLoggedInUser(User);

            if(authenticatedUser != null)
            {
                return Ok(_userMapper.toDTO(authenticatedUser));
            }

            return BadRequest("Could not find user");
        }
    }

}