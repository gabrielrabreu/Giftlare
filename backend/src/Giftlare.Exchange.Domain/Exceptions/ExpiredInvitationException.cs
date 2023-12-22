using Giftlare.Core.Domain.Exceptions;
using Giftlare.Infra.Resources;

namespace Giftlare.Exchange.Domain.Exceptions
{
    public class ExpiredInvitationException : DomainException
    {
        public ExpiredInvitationException()
            : base("ExpiredInvitation",
                   GiftlareResource.ExpiredInvitation,
                   GiftlareResource.ExpiredInvitationMessage)
        {
        }
    }
}
