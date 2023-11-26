using Giftlare.Infra.Resources;

namespace Giftlare.Core.Domain.Exceptions
{
    public class FieldRequiredException : DomainException
    {
        public FieldRequiredException(string name)
            : base("FieldRequired",
                   GiftlareResource.FieldRequired,
                   string.Format(GiftlareResource.FieldRequiredMessage, name))
        {
        }
    }
}
