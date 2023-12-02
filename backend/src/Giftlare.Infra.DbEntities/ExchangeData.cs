using Giftlare.Core.Infra.Data.Entities;

namespace Giftlare.Infra.DbEntities
{
    public class ExchangeData : AuditableEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string InviteToken { get; set; }
        public virtual ICollection<ExchangeMemberData> Members { get; set; }
    }
}
