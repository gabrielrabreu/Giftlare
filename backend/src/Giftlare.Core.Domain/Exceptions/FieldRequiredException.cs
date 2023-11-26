using Giftlare.Infra.Resources;

namespace Giftlare.Core.Domain.Exceptions
{
    public class FieldRequiredException : DomainException
    {
        public FieldRequiredException(string fieldName) 
            : base("FieldRequired", 
                   GiftlareResource.FieldRequired, 
                   string.Format(GiftlareResource.FieldRequiredMessage, fieldName))
        {
        }
    }
}
