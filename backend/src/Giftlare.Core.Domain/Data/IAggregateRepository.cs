using Giftlare.Core.Domain.Entities;

namespace Giftlare.Core.Domain.Data
{
    public interface IAggregateRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
    {
        IList<TAggregateRoot> GetAll();
        TAggregateRoot? GetById(Guid domainEntityId);

        void Add(TAggregateRoot domainEntity);
        void Update(TAggregateRoot domainEntity);
        void Delete(Guid domainEntityId);

        int CommitChanges();
        void RollBackChanges();
    }
}
