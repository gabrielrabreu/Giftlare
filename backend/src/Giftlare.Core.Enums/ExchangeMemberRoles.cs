using Giftlare.Infra.Resources;
using System.ComponentModel.DataAnnotations;

namespace Giftlare.Core.Enums
{
    public enum ExchangeMemberRoles
    {
        [Display(Description = "Administrator", ResourceType = typeof(GiftlareResource))]
        ADMIN = 0,

        [Display(Description = "Member", ResourceType = typeof(GiftlareResource))]
        MEMBER = 1
    }
}
