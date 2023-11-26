using Giftlare.Core.Domain.Data;
using Giftlare.Exchange.Contracts;
using Giftlare.Exchange.Domain.Queries.Parameters;

namespace Giftlare.Exchange.Domain.Queries
{
    public interface IExchangeQuery
    {
        IPagedList<ExchangeDto> Paginate(IExchangePagedParameters parameters);
    }
}
