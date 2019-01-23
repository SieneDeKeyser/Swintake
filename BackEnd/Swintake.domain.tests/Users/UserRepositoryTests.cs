using Microsoft.EntityFrameworkCore;
using Swintake.domain.Data;
using Swintake.domain.Users;
using System;
using Xunit;

namespace Swintake.domain.tests.Users
{
    public class UserRepositoryTests
    {
        [Fact]
        public void GivenEmailAddress_WhenFindByEmail_ThenReturnUser()
        {
            //given
            var options = new DbContextOptionsBuilder<SwintakeContext>()
                .UseInMemoryDatabase("swintake" + Guid.NewGuid().ToString("n"))
                .Options;

            using (var context = new SwintakeContext(options))
            {
                var user = new UserBuilder()
                        .WithEmail("user@switchfully.com")
                        .WithFirstName("User")
                        .WithUserSecurity(new UserSecurity("WO8nNwTcrxigARQfBn4nYRh8X16ExDQJ8jNuECJT8fE=", "F1e3n6zNR75LhUd5K73T/g=="))
                        .Build();

                context.Users.Add(user);

                context.SaveChanges();

                IUserRepository userRepository = new UserRepository(context);

                //when
                var foundUser = userRepository.FindByEmail("user@switchfully.com");

                //then
                Assert.Equal(user.Id, foundUser.Id);
                Assert.Equal(user.Email, foundUser.Email);
                Assert.Equal(user.FirstName, foundUser.FirstName);
                Assert.Equal(user.UserSecurity.AppliedSalt, foundUser.UserSecurity.AppliedSalt);
                Assert.Equal(user.UserSecurity.PasswordHashedAndSalted, foundUser.UserSecurity.PasswordHashedAndSalted);
            }
        }

        [Fact]
        public void GivenUnKnownEmailAddress_WhenFindByEmail_ThenReturnNull()
        {
            //given
            var options = new DbContextOptionsBuilder<SwintakeContext>()
                .UseInMemoryDatabase("swintake" + Guid.NewGuid().ToString("n"))
                .Options;

            using (var context = new SwintakeContext(options))
            {
                IUserRepository userRepository = new UserRepository(context);

                //when
                var foundUser = userRepository.FindByEmail("user1@switchfully.com");

                //then
                Assert.Null(foundUser);
            }
        }
    }
}
