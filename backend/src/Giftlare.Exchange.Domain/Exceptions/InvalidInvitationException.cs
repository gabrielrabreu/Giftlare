using Giftlare.Core.Domain.Exceptions;
using Giftlare.Infra.Resources;

namespace Giftlare.Exchange.Domain.Exceptions
{
    public class InvalidInvitationException : DomainException
    {
        public InvalidInvitationException()
            : base("InvalidInvitation",
                   GiftlareResource.InvalidInvitation,
                   GiftlareResource.InvalidInvitationMessage)
        {
        }
    }
}
