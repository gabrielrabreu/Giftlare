using Giftlare.Infra.Resources;

namespace Giftlare.Main.Domain.Exceptions
{
    public class InvalidInvitationException : InvitationException
    {
        public InvalidInvitationException()
            : base(GiftlareResource.InvalidInvitation)
        {
        }
    }
}
