using Swintake.domain.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Swintake.services.Users
{
    public interface IUserAuthenticationService
    {
        JwtSecurityToken Authenticate(string providedEmail, string providedPassword);
        User GetCurrentLoggedInUser(ClaimsPrincipal principleUser);
    }
}
