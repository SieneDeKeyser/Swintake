using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.domain.Users
{
    public interface IUserRepository
    {
        User FindByEmail(string email);
    }
}
