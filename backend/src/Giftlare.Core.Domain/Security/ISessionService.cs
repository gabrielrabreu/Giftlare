namespace Giftlare.Core.Domain.Security
{
    public interface ISessionService
    {
        IAuthenticatedUser User { get; }

        bool IsAuthenticated();

        void Authenticate(IAuthenticatedUser user);
    }
}
