using System.ComponentModel.DataAnnotations;

namespace Giftlare.Enums
{
    public enum GatheringMemberRoles
    {
        [Display(Description = "Admin")]
        Admin,

        [Display(Description = "Member")]
        Member
    }
}