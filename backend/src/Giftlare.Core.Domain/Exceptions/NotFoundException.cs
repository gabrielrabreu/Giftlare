using Giftlare.Infra.Resources;

namespace Giftlare.Core.Domain.Exceptions
{
    public class NotFoundException : DomainException
    {
        public NotFoundException(string entityName) 
            : base("NotFound", 
                   GiftlareResource.NotFound, 
                   string.Format(GiftlareResource.NotFoundMessage, entityName))
        {
        }
    }
}
