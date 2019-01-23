using SecuredWebApi.Services.Security;
using Swintake.services.Users.Security;
using System;

namespace zzPasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Salter salter = new Salter();
            var salt = salter.CreateRandomSalt();
            Console.WriteLine(salt);
            Hasher hasher = new Hasher();
            var hash = hasher.CreateHashOfPasswordAndSalt("ILoveNiels", salt);
            Console.WriteLine(hash);
        }
    }
}
