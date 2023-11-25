using Giftlare.Core.Domain.Data;
using Giftlare.Core.Domain.Entities;
using Giftlare.Core.Domain.Security;
using Giftlare.Core.Infra.Data.Context;
using Giftlare.Core.Infra.Data.Entities;

namespace Giftlare.Core.Infra.Data.Repositories
{
    public abstract class AuditableRepository<TDomainEntity, TDataEntity> : EntityRepository<TDomainEntity, TDataEntity>, IEntityRepository<TDomainEntity>
        where TDomainEntity : DomainEntity
        where TDataEntity : AuditableEntity
    {
        protected readonly ISessionService _sessionService;

        protected AuditableRepository(IApplicationDbContext context,
                                      ISessionService sessionService)
            : base(context)
        {
            _sessionService = sessionService;
        }

        public override TDomainEntity Add(TDomainEntity domainEntity)
        {
            var dataEntity = MapTo(domainEntity);
            dataEntity.OnCreate(_sessionService.User?.Id ?? Guid.Empty);
            _dbSet.Add(dataEntity);
            return domainEntity;
        }

        public override void Update(TDomainEntity domainEntity)
        {
            var dataEntity = MapTo(domainEntity);
            dataEntity.OnUpdate(_sessionService.User?.Id ?? Guid.Empty);
            _dbSet.Update(dataEntity);

            var entry = _context.GetDbEntry(dataEntity);
            if (entry != null)
            {
                entry.Property(x => x.CreatedBy).IsModified = false;
                entry.Property(x => x.CreatedOn).IsModified = false;
            }
        }
    }
}
