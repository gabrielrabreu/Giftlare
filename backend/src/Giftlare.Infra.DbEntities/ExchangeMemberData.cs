using Giftlare.Core.Enums;
using Giftlare.Core.Infra.Data.Entities;

namespace Giftlare.Infra.DbEntities
{
    public class ExchangeMemberData : AuditableEntity
    {
        public Guid ExchangeId { get; set; }
        public virtual ExchangeData Exchange { get; set; }

        public Guid MemberId { get; set; }
        public virtual ApplicationUser Member { get; set; }

        public ExchangeMemberRoles Role { get; set; }
    }
}
