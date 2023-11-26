using Giftlare.Infra.Resources;

namespace Giftlare.Main.Domain.Exceptions
{
    public class NotFoundInvitationException : InvitationException
    {
        public NotFoundInvitationException()
            : base(GiftlareResource.NotFoundInvitation)
        {
        }
    }
}
