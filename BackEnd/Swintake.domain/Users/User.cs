using Swintake.infrastructure.builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.domain.Users
{
    public class User : Entity
    {
        public string FirstName { get; private set; }
        public string Email { get; private set; }
        public UserSecurity UserSecurity { get; private set; }

        private User() { }

        public User(UserBuilder userBuilder) : base(userBuilder.Id)
        {
            FirstName = userBuilder.FirstName;
            Email = userBuilder.Email;
            UserSecurity = userBuilder.UserSecurity;
        }
    }

    public class UserBuilder : Builder<User>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public UserSecurity UserSecurity { get; set; }

        public static UserBuilder User()
        {
            return new UserBuilder();
        }

        public override User Build()
        {
            return new User(this);
        }

        public UserBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }
        public UserBuilder WithFirstName(string firstName)
        {
            FirstName = firstName;
            return this;
        }

        public UserBuilder WithEmail(string email)
        {
            Email = email;
            return this;
        }

        public UserBuilder WithUserSecurity(UserSecurity userSecurity)
        {
            UserSecurity = userSecurity;
            return this;
        }
    }
}
