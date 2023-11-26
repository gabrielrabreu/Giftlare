using Giftlare.Core.Infra.Data.Entities;
using Giftlare.Enums;

namespace Giftlare.Infra.DbEntities
{
    public class GatheringMemberData : AuditableEntity
    {
        public Guid GatheringId { get; set; }
        public virtual GatheringData Gathering { get; set; }

        public Guid MemberId { get; set; }
        public virtual ApplicationUser Member { get; set; }

        public GatheringMemberRoles Role { get; set; }
    }
}
