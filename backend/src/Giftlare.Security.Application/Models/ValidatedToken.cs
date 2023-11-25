namespace Giftlare.Security.Application.Models
{
    public class ValidatedToken
    {
        public bool IsValid { get; set; }
        public AuthenticatedUser User { get; set; } = new AuthenticatedUser();
    }
}
