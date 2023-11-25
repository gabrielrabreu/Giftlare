using Giftlare.Infra.Resources;

namespace Giftlare.Core.Domain.Exceptions
{
    public abstract class InvalidAuthenticationMethodException : DetailedException
    {
        protected InvalidAuthenticationMethodException(string detail)
            : base("InvalidAuthenticationMethod", GiftlareResource.InvalidAuthenticationMethod, detail)
        {
        }
    }
}
