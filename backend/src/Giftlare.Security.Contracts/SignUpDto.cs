using System.ComponentModel.DataAnnotations;

namespace Giftlare.Security.Contracts
{
    public class SignUpDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string Language { get; set; } = string.Empty;
    }
}
