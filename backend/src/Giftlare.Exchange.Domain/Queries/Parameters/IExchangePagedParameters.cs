using Giftlare.Core.Domain.Data;

namespace Giftlare.Exchange.Domain.Queries.Parameters
{
    public interface IExchangePagedParameters : IPagedParameters
    {
        public Guid MemberId { get; set; }
    }
}
