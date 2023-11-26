using Giftlare.Core.Domain.Data;
using Giftlare.Core.Domain.Entities;
using Giftlare.Core.Infra.Data.Context;
using Giftlare.Core.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Giftlare.Core.Infra.Data.Repositories
{
    public abstract class EntityRepository<TDomainEntity, TDataEntity> : IEntityRepository<TDomainEntity>
        where TDomainEntity : IAggregateRoot
        where TDataEntity : DataEntity
    {
        protected readonly IApplicationDbContext _context;
        protected readonly DbSet<TDataEntity> _dbSet;

        protected EntityRepository(IApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.GetDbSet<TDataEntity>();
        }

        public virtual IList<TDomainEntity> GetAll()
        {
            var dataEntities = _dbSet.AsNoTracking().ToList();
            return dataEntities.Select(MapTo).ToList();
        }

        public virtual TDomainEntity? GetById(Guid domainEntityId)
        {
            var dataEntity = _dbSet.AsNoTracking().SingleOrDefault(x => x.Id.Equals(domainEntityId));
            if (dataEntity != null)
                return MapTo(dataEntity);
            return default;
        }

        public virtual bool Exists(Guid domainEntityId)
        {
            return _dbSet.Any(x => x.Id == domainEntityId);
        }

        public virtual TDomainEntity Add(TDomainEntity domainEntity)
        {
            var dataEntity = MapTo(domainEntity);
            _dbSet.Add(dataEntity);
            return domainEntity;
        }

        public virtual void Update(TDomainEntity domainEntity)
        {
            var dataEntity = MapTo(domainEntity);
            _dbSet.Update(dataEntity);
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

        protected abstract TDomainEntity MapTo(TDataEntity dataEntity);
        protected abstract TDataEntity MapTo(TDomainEntity domainEntity);
    }
}
