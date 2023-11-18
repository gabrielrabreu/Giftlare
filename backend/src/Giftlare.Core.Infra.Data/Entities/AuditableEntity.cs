namespace Giftlare.Core.Infra.Data.Entities
{
    public abstract class AuditableEntity : DataEntity
    {
        public Guid CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public Guid? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }

        protected AuditableEntity()
        {
            CreatedBy = Guid.Empty;
            CreatedOn = DateTimeOffset.MinValue;
        }

        public void OnCreate(Guid createdBy)
        {
            CreatedBy = createdBy;
            CreatedOn = DateTimeOffset.UtcNow;
        }

        public void OnUpdate(Guid lastModifiedBy)
        {
            LastModifiedBy = lastModifiedBy;
            LastModifiedOn = DateTimeOffset.UtcNow;
        }
    }
}
