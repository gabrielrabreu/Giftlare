using Giftlare.Core.Domain.Data;
using Giftlare.Exchange.Contracts;
using Giftlare.Exchange.Domain.Queries.Parameters;

namespace Giftlare.Exchange.Application.AppQueries.Interfaces
{
    public interface IExchangeAppQuery
    {
        IPagedList<ExchangeDto> Paginate(IExchangePagedParameters parameters);
    }
}
