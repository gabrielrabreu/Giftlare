using Giftlare.Core.Domain.Exceptions;
using Giftlare.Infra.Resources;

namespace Giftlare.Exchange.Domain.Exceptions
{
    public class AdminRequiredException : DomainException
    {
        public AdminRequiredException()
            : base("AdminRequired",
                   GiftlareResource.AdminRequired,
                   GiftlareResource.AdminRequiredMessage)
        {
        }
    }
}
