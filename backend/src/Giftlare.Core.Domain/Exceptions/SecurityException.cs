namespace Giftlare.Core.Domain.Exceptions
{
    public abstract class SecurityException : GiftlareException
    {
        protected SecurityException(string type, string error, string detail) : base(type, error, detail)
        {
        }
    }
}
