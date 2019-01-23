using System;

namespace Swintake.infrastructure.Exceptions
{
    public class NotAuthorizedException : Exception
    {
        public NotAuthorizedException(string additionalContext)
         :base(additionalContext)
        {
        }
    }
}
