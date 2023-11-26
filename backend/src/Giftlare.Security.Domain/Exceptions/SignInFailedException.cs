using Giftlare.Core.Domain.Exceptions;
using Giftlare.Infra.Resources;

namespace Giftlare.Security.Domain.Exceptions
{
    public class SignInFailedException : SecurityException
    {
        public SignInFailedException() 
            : base(nameof(GiftlareResource.SignInFailed),
                   GiftlareResource.SignInFailed,
                   GiftlareResource.SignInFailedMessage)
        {
        }
    }
}
