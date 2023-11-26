using Giftlare.Core.Domain.Data;
using Giftlare.Main.Application.AppQueries.Interfaces;
using Giftlare.Main.Contracts;
using Giftlare.Main.Domain.Queries;
using Giftlare.Main.Domain.Queries.Parameters;

namespace Giftlare.Main.Application.AppQueries
{
    public class GatheringAppQuery : IGatheringAppQuery
    {
        private readonly IGatheringQuery _query;

        public GatheringAppQuery(IGatheringQuery query)
        {
            _query = query;
        }

        public IPagedList<GatheringDto> Paginate(IGatheringParameters parameters)
        {
            return _query.Paginate(parameters);
        }
    }
}
