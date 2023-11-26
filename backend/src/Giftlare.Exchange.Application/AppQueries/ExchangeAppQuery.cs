using Giftlare.Core.Domain.Data;
using Giftlare.Exchange.Application.AppQueries.Interfaces;
using Giftlare.Exchange.Contracts;
using Giftlare.Exchange.Domain.Queries;
using Giftlare.Exchange.Domain.Queries.Parameters;

namespace Giftlare.Exchange.Application.AppQueries
{
    public class ExchangeAppQuery : IExchangeAppQuery
    {
        private readonly IExchangeQuery _query;

        public ExchangeAppQuery(IExchangeQuery query)
        {
            _query = query;
        }

        public IPagedList<ExchangeDto> Paginate(IExchangePagedParameters parameters)
        {
            return _query.Paginate(parameters);
        }
    }
}
