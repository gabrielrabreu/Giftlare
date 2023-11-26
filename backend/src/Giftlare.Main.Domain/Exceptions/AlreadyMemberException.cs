using Giftlare.Core.Domain.Exceptions;
using Giftlare.Infra.Resources;

namespace Giftlare.Main.Domain.Exceptions
{
    public class AlreadyMemberException : DomainException
    {
        public AlreadyMemberException()
            : base("AlreadyMember", GiftlareResource.AlreadyMember, GiftlareResource.AlreadyMemberMessage)
        {
        }
    }
}
