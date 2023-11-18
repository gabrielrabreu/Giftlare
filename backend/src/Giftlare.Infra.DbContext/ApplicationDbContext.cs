using Giftlare.Core.Infra.Data.Context;
using Giftlare.Core.Infra.Data.Entities;
using Giftlare.Infra.DbEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace Giftlare.Infra.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public bool CanConnect()
        {
            return Database.CanConnect();
        }

        public DbSet<TDataEntity> GetDbSet<TDataEntity>() where TDataEntity : DataEntity
        {
            return Set<TDataEntity>();
        }

        public EntityEntry<TDataEntity> GetDbEntry<TDataEntity>(TDataEntity dataEntity) where TDataEntity : DataEntity
        {
            return Entry(dataEntity);
        }

        public IQueryable<TDataEntity> Query<TDataEntity>() where TDataEntity : DataEntity
        {
            return Set<TDataEntity>().AsQueryable();
        }

        public void AddData<TDataEntity>(TDataEntity dataEntity) where TDataEntity : DataEntity
        {
            Add(dataEntity);
        }

        public void UpdateData<TDataEntity>(TDataEntity dataEntity) where TDataEntity : DataEntity
        {
            Update(dataEntity);
        }

        public void DeleteData<TDataEntity>(TDataEntity dataEntity) where TDataEntity : DataEntity
        {
            Remove(dataEntity);
        }

        public int CommitChanges()
        {
            return SaveChanges();
        }

        public void RollBackChanges()
        {
            Database.RollbackTransaction();
        }
    }
}
