using Giftlare.Core.Domain.Exceptions;
using Giftlare.Infra.Resources;

namespace Giftlare.Security.Domain.Exceptions
{
    public class AuthenticationFailedException : SecurityException
    {
        public AuthenticationFailedException() 
            : base("AuthenticationFailed",
                   GiftlareResource.AuthenticationFailed,
                   GiftlareResource.AuthenticationFailedMessage)
        {
        }
    }
}
