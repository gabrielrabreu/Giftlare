using Giftlare.Core.Domain.Data;
using Giftlare.Core.Domain.Entities;
using Giftlare.Core.Infra.Data.Context;
using Giftlare.Core.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Giftlare.Core.Infra.Data.Repositories
{
    public abstract class AggregateRepository<TAggregateRoot, TDataEntity> : IAggregateRepository<TAggregateRoot>
        where TAggregateRoot : IAggregateRoot
        where TDataEntity : DataEntity
    {
        protected readonly IApplicationDbContext _context;
        protected readonly DbSet<TDataEntity> _dbSet;

        protected AggregateRepository(IApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.GetDbSet<TDataEntity>();
        }

        public int CommitChanges()
        {
            return _context.CommitChanges();
        }

        public void RollBackChanges()
        {
            _context.RollBackChanges();
        }
    }
}
