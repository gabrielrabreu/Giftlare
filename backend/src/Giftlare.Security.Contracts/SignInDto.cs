using System.ComponentModel.DataAnnotations;

namespace Giftlare.Security.Contracts
{
    public class SignInDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}