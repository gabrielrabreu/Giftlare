using Giftlare.Infra.Resources;

namespace Giftlare.Core.Domain.Exceptions
{
    public abstract class OperationFailedException : DetailedException
    {
        protected OperationFailedException(string detail)
            : base("OperationFailed", GiftlareResource.OperationFailed, detail)
        {
        }
    }
}
