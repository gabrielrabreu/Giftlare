namespace Giftlare.Security.Application.Settings
{
    public class AuthSettings
    {
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string Secret { get; set; } = string.Empty;
        public int ExpiresInHours { get; set; } = 0;
    }
}
