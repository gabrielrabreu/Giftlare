using Giftlare.Core.Domain.Data;
using Giftlare.Exchange.Contracts;
using Giftlare.Exchange.Domain.Queries.Parameters;

namespace Giftlare.Exchange.Application.AppQueries.Interfaces
{
    public interface IExchangeAppQuery
    {
        ExchangeDto? GetById(Guid memberId, Guid id);

        IPagedList<ExchangeDto> Paginate(Guid memberId, IExchangePagedParameters parameters);
    }
}
