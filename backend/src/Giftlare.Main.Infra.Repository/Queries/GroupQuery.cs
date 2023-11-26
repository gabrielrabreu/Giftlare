using Giftlare.Core.Domain.Data;
using Giftlare.Core.Infra.Data.Context;
using Giftlare.Core.Infra.Data.Queries;
using Giftlare.Infra.DbEntities;
using Giftlare.Main.Contracts;
using Giftlare.Main.Domain.Queries;
using Giftlare.Main.Domain.Queries.Parameters;

namespace Giftlare.Main.Infra.Repository.Queries
{
    public class GroupQuery : IGatheringQuery
    {
        private readonly IApplicationDbContext _context;

        public GroupQuery(IApplicationDbContext context)
        {
            _context = context;
        }

        public IPagedList<GatheringDto> Paginate(IGroupParameters parameters)
        {
            var source = _context.Query<GroupData>();

            var totalItems = source.Count();

            source = source.OrderBy(p => p.Name);

            var dtos = (from s in source
                        select new GatheringDto()
                        {
                            Name = s.Name
                        })
                        .Skip(parameters.Page * parameters.Size)
                        .Take(parameters.Size)
                        .ToList();

            return new PagedList<GatheringDto>(dtos, totalItems, parameters.Page, parameters.Size);
        }
    }
}
