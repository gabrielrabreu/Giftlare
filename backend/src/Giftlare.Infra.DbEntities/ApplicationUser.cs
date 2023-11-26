using Giftlare.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace Giftlare.Infra.DbEntities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? Name { get; set; }
        public Languages Language { get; set; }
        public virtual ICollection<ExchangeMemberData> Exchanges { get; set; }
    }
}
