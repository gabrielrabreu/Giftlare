using Giftlare.Core.Domain.Exceptions;
using Giftlare.Infra.Resources;

namespace Giftlare.Security.Domain.Exceptions
{
    public class SignInFailedException : OperationFailedException
    {
        public SignInFailedException() : base(GiftlareResource.SignInFailed)
        {
        }
    }
}
