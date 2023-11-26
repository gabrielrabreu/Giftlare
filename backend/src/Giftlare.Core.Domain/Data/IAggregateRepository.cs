using Giftlare.Core.Domain.Entities;

namespace Giftlare.Core.Domain.Data
{
    public interface IAggregateRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
    {
        int CommitChanges();
        void RollBackChanges();
    }
}
