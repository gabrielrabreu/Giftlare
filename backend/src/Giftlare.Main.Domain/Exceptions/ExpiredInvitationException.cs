using Giftlare.Infra.Resources;

namespace Giftlare.Main.Domain.Exceptions
{
    public class ExpiredInvitationException : InvitationException
    {
        public ExpiredInvitationException()
            : base(GiftlareResource.ExpiredInvitation)
        {
        }
    }
}
