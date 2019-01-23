using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.domain.Users
{
    public class UserSecurity
    {
        public string PasswordHashedAndSalted { get; private set; }
        public string AppliedSalt { get; private set; }

        private UserSecurity()
        {
        }

        public UserSecurity(string passwordHashedAndSalted, string appliedSalt)
        {
            PasswordHashedAndSalted = passwordHashedAndSalted;
            AppliedSalt = appliedSalt;
        }
    }
}
