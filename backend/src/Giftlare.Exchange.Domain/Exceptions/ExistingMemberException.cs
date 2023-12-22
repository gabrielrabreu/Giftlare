using Giftlare.Core.Domain.Exceptions;
using Giftlare.Infra.Resources;

namespace Giftlare.Exchange.Domain.Exceptions
{
    public class ExistingMemberException : DomainException
    {
        public ExistingMemberException()
            : base("ExistingMember",
                   GiftlareResource.ExistingMember,
                   GiftlareResource.ExistingMemberMessage)
        {
        }
    }
}
