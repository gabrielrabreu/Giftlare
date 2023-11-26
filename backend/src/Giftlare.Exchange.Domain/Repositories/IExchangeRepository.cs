using Giftlare.Core.Domain.Data;
using Giftlare.Exchange.Domain.Entities;

namespace Giftlare.Exchange.Domain.Repositories
{
    public interface IExchangeRepository : IAggregateRepository<ExchangeDomain>
    {
        ExchangeDomain? GetById(Guid id);

        void Add(ExchangeDomain domain);
        void Update(ExchangeDomain domain);
    }
}
