using Giftlare.Core.Domain.Data;
using Giftlare.Core.Domain.Entities;
using Giftlare.Core.Domain.Security;
using Giftlare.Core.Infra.Data.Context;
using Giftlare.Core.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Giftlare.Core.Infra.Data.Repositories
{
    public abstract class AggregateRepository<TAggregateRoot, TDataEntity> : IAggregateRepository<TAggregateRoot>
        where TAggregateRoot : IAggregateRoot
        where TDataEntity : AuditableEntity
    {
        protected readonly IApplicationDbContext _context;
        protected readonly ISessionService _sessionService;
        protected readonly DbSet<TDataEntity> _dbSet;

        protected AggregateRepository(IApplicationDbContext context, ISessionService sessionService)
        {
            _context = context;
            _sessionService = sessionService;
            _dbSet = _context.GetDbSet<TDataEntity>();
        }

        public virtual IList<TAggregateRoot> GetAll()
        {
            var dataEntities = _dbSet.AsNoTracking().ToList();
            return dataEntities.Select(MapTo).ToList();
        }

        public virtual TAggregateRoot? GetById(Guid domainEntityId)
        {
            var dataEntity = _dbSet.AsNoTracking()
                .SingleOrDefault(x => x.Id.Equals(domainEntityId));
            
            if (dataEntity != null)
                return MapTo(dataEntity);

            return default;
        }

        public virtual void Add(TAggregateRoot domainEntity)
        {
            var dataEntity = MapTo(domainEntity);
            dataEntity.OnCreate(_sessionService.User.Id);
            _dbSet.Add(dataEntity);
        }

        public virtual void Update(TAggregateRoot domainEntity)
        {
            var dataEntity = MapTo(domainEntity);
            dataEntity.OnUpdate(_sessionService.User.Id);
            _dbSet.Update(dataEntity);

            var entry = _context.GetDbEntry(dataEntity);
            if (entry != null)
            {
                entry.Property(x => x.CreatedBy).IsModified = false;
                entry.Property(x => x.CreatedOn).IsModified = false;
            }
        }

        public virtual void Delete(Guid domainEntityId)
        {
            var dataEntity = _dbSet.SingleOrDefault(x => x.Id == domainEntityId);
            if (dataEntity != null) _dbSet.Remove(dataEntity);
        }

        public int CommitChanges()
        {
            return _context.CommitChanges();
        }

        public void RollBackChanges()
        {
            _context.RollBackChanges();
        }

        protected abstract TAggregateRoot MapTo(TDataEntity dataEntity);
        protected abstract TDataEntity MapTo(TAggregateRoot domainEntity);
    }
}
