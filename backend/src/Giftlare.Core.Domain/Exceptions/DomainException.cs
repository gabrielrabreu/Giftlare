namespace Giftlare.Core.Domain.Exceptions
{
    public abstract class DomainException : GiftlareException
    {
        protected DomainException(string type, string error, string detail) : base(type, error, detail)
        {
        }
    }
}
