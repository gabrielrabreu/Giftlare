using Giftlare.Core.Domain.Security;
using Giftlare.Security.Application.Models;

namespace Giftlare.Security.Application.Services
{
    public class SessionService : ISessionService
    {
        public IAuthenticatedUser User { get; private set; } = new AuthenticatedUser();

        public bool IsAuthenticated()
        {
            return User.Id != Guid.Empty;
        }

        public void Authenticate(IAuthenticatedUser user)
        {
            User = user;
        }
    }
}
