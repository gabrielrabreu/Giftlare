using Giftlare.Core.Domain.Data;
using Giftlare.Main.Contracts;
using Giftlare.Main.Domain.Queries.Parameters;

namespace Giftlare.Main.Application.AppQueries.Interfaces
{
    public interface IGatheringAppQuery
    {
        IPagedList<GatheringDto> Paginate(IGatheringParameters parameters);
    }
}
