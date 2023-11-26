namespace Giftlare.Core.Domain.Exceptions
{
    public abstract class DomainException : DetailedException
    {
        protected DomainException(string type, string error, string detail) : base(type, error, detail)
        {
        }
    }
}
