using Giftlare.Core.Infra.Data.Entities;

namespace Giftlare.Infra.DbEntities
{
    public class GroupData : AuditableEntity
    {
        public string Name { get; set; }
        public string InviteToken { get; set; }
    }
}
