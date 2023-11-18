using Giftlare.Core.Domain.Entities;

namespace Giftlare.Core.Domain.Data
{
    public interface IEntityRepository<TDomainEntity> where TDomainEntity : DomainEntity
    {
        IList<TDomainEntity> GetAll();
        TDomainEntity? GetById(Guid domainEntityId);

        bool Exists(Guid domainEntityId);

        TDomainEntity Add(TDomainEntity domainEntity);
        void Update(TDomainEntity domainEntity);
        void Delete(Guid domainEntityId);

        int CommitChanges();
        void RollBackChanges();
    }
}
