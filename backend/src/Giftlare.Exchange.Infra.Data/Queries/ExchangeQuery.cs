using Giftlare.Core.Domain.Data;
using Giftlare.Core.Domain.Extensions;
using Giftlare.Core.Infra.Data.Context;
using Giftlare.Core.Infra.Data.Queries;
using Giftlare.Exchange.Contracts;
using Giftlare.Exchange.Domain.Queries;
using Giftlare.Exchange.Domain.Queries.Parameters;
using Giftlare.Infra.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Giftlare.Exchange.Infra.Data.Queries
{
    public class ExchangeQuery : IExchangeQuery
    {
        private readonly IApplicationDbContext _context;

        public ExchangeQuery(IApplicationDbContext context)
        {
            _context = context;
        }

        public ExchangeDto? GetById(Guid memberId, Guid id)
        {
            var source = _context.Query<ExchangeData>()
                .Include(x => x.Members).ThenInclude(x => x.Member)
                .FirstOrDefault(x => x.Members.Any(x => x.MemberId == memberId) && x.Id == id);

            if (source == null) return null;

            return new ExchangeDto()
            {
                Id = source.Id,
                Name = source.Name,
                Image = source.Image,
                Members = source.Members.Select(m =>
                    new ExchangeMemberDto()
                    {
                        Name = m.Member.Name,
                        Role = m.Role,
                        RoleDescription = m.Role.GetEnumDisplayDescription()
                    }).ToList()
            };
        }

        public IPagedList<ExchangeDto> Paginate(Guid memberId, IExchangePagedParameters parameters)
        {
            var source = _context.Query<ExchangeData>()
                .Include(x => x.Members).ThenInclude(x => x.Member)
                .Where(x => x.Members.Any(x => x.MemberId == memberId));

            var totalItems = source.Count();

            source = source.OrderBy(p => p.Name);

            var dtos = (from exchange in source
                        select new ExchangeDto()
                        {
                            Id = exchange.Id,
                            Name = exchange.Name,
                            Image = exchange.Image,
                            Members = exchange.Members.Select(m =>
                                new ExchangeMemberDto()
                                {
                                    Name = m.Member.Name,
                                    Role = m.Role,
                                    RoleDescription = m.Role.GetEnumDisplayDescription()
                                }).ToList()
                        })
                        .Skip(parameters.Page * parameters.Size)
                        .Take(parameters.Size)
                        .ToList();

            return new PagedList<ExchangeDto>(dtos, totalItems, parameters.Page, parameters.Size);
        }
    }
}
