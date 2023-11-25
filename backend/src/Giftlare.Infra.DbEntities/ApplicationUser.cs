using Giftlare.Infra.Resources;
using Microsoft.AspNetCore.Identity;

namespace Giftlare.Infra.DbEntities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? Name { get; set; }
        public Language Language { get; set; }
    }
}
