using Giftlare.Core.Domain.Data;
using Giftlare.Core.Domain.Extensions;
using Giftlare.Core.Infra.Data.Context;
using Giftlare.Core.Infra.Data.Queries;
using Giftlare.Exchange.Contracts;
using Giftlare.Exchange.Domain.Queries;
using Giftlare.Exchange.Domain.Queries.Parameters;
using Giftlare.Infra.DbEntities;

namespace Giftlare.Exchange.Infra.Data.Queries
{
    public class ExchangeQuery : IExchangeQuery
    {
        private readonly IApplicationDbContext _context;

        public ExchangeQuery(IApplicationDbContext context)
        {
            _context = context;
        }

        public IPagedList<ExchangeDto> Paginate(IExchangePagedParameters parameters)
        {
            var source = _context.Query<ExchangeData>()
                .Where(x => x.Members.Any(x => x.MemberId == parameters.MemberId));

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
                                    Role = m.Role.GetEnumDisplayDescription()
                                }).ToList()
                        })
                        .Skip(parameters.Page * parameters.Size)
                        .Take(parameters.Size)
                        .ToList();

            return new PagedList<ExchangeDto>(dtos, totalItems, parameters.Page, parameters.Size);
        }
    }
}
