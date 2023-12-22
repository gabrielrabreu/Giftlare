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

        public ExchangeDto? GetById(Guid memberId, Guid id)
        {
            return _query.GetById(memberId, id);
        }

        public IPagedList<ExchangeDto> Paginate(Guid memberId, IExchangePagedParameters parameters)
        {
            return _query.Paginate(memberId, parameters);
        }
    }
}
