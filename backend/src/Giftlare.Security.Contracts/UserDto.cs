using System.ComponentModel.DataAnnotations;

namespace Giftlare.Security.Contracts
{
    public class UserDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Language { get; set; } = string.Empty;
    }
}
