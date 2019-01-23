using Swintake.domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swintake.api.Helpers.Users
{
    public class UserMapper
    {
        public UserReplyDTO toDTO(User user)
        {
            return new UserReplyDTO { FirstName = user.FirstName };
        }

    }
}
