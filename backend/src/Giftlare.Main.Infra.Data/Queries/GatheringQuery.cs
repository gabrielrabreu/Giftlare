using Giftlare.Core.Domain.Data;
using Giftlare.Core.Domain.Extensions;
using Giftlare.Core.Infra.Data.Context;
using Giftlare.Core.Infra.Data.Queries;
using Giftlare.Infra.DbEntities;
using Giftlare.Main.Contracts;
using Giftlare.Main.Domain.Queries;
using Giftlare.Main.Domain.Queries.Parameters;

namespace Giftlare.Main.Infra.Repository.Queries
{
    public class GatheringQuery : IGatheringQuery
    {
        private readonly IApplicationDbContext _context;

        public GatheringQuery(IApplicationDbContext context)
        {
            _context = context;
        }

        public IPagedList<GatheringDto> Paginate(IGatheringParameters parameters)
        {
            var gatherings = _context.Query<GatheringData>();

            var totalItems = gatherings.Count();

            gatherings = gatherings.OrderBy(p => p.Name);

            var dtos = (from gathering in gatherings
                        select new GatheringDto()
                        {
                            Id = gathering.Id,
                            Name = gathering.Name,
                            Members = gathering.Members.Select(m => 
                                new GatheringMemberDto()
                                {
                                    Name = m.Member.Name,
                                    Role = m.Role.GetEnumDisplayDescription()
                                }).ToList()
                        })
                        .Skip(parameters.Page * parameters.Size)
                        .Take(parameters.Size)
                        .ToList();

            return new PagedList<GatheringDto>(dtos, totalItems, parameters.Page, parameters.Size);
        }
    }
}
