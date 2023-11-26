using Giftlare.Core.Infra.Data.Entities;

namespace Giftlare.Infra.DbEntities
{
    public class GatheringData : AuditableEntity
    {
        public string Name { get; set; }
        public Guid InviteToken { get; set; }
        public virtual ICollection<GatheringMemberData> Members { get; set; }
    }
}
