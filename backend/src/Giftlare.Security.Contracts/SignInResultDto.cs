using System.ComponentModel.DataAnnotations;

namespace Giftlare.Security.Contracts
{
    public class SignInResultDto
    {
        [Required]
        public string Token { get; set; } = string.Empty;

        [Required]
        public UserDto User { get; set; } = new UserDto();
    }
}
