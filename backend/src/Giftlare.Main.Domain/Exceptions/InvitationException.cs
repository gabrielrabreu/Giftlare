using Giftlare.Core.Domain.Exceptions;
using Giftlare.Infra.Resources;

namespace Giftlare.Main.Domain.Exceptions
{
    public abstract class InvitationException : DomainException
    {
        protected InvitationException(string detail) : base("InvalidInvitation", GiftlareResource.InvalidInvitation, detail)
        {
        }
    }
}
