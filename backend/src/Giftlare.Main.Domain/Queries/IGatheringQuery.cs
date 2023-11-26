using Giftlare.Core.Domain.Data;
using Giftlare.Main.Contracts;
using Giftlare.Main.Domain.Queries.Parameters;

namespace Giftlare.Main.Domain.Queries
{
    public interface IGatheringQuery
    {
        IPagedList<GatheringDto> Paginate(IGatheringParameters parameters);
    }
}
