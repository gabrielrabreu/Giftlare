using Giftlare.Core.Infra.Data.Entities;
using Giftlare.Enums;

namespace Giftlare.Infra.DbEntities
{
    public class GroupUserData : AuditableEntity
    {
        public Guid GroupId { get; set; }
        public Guid UserId { get; set; }
        public GroupUserRole Role { get; set; }
    }
}
