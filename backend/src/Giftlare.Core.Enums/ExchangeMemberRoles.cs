using Giftlare.Infra.Resources;
using System.ComponentModel.DataAnnotations;
using System.Resources;

namespace Giftlare.Core.Enums
{
    public enum ExchangeMemberRoles
    {
        [Display(Description = "Administrator", ResourceType = typeof(GiftlareResource))]
        Admin,

        [Display(Description = "Member", ResourceType = typeof(GiftlareResource))]
        Member
    }
}
