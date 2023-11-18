using Giftlare.Core.Domain.Security;

namespace Giftlare.Security.Application.Models
{
    public class AuthenticatedUser : IAuthenticatedUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
    }
}
