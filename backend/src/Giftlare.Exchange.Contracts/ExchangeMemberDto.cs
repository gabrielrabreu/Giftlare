using Giftlare.Core.Enums;

namespace Giftlare.Exchange.Contracts
{
    public class ExchangeMemberDto
    {
        public string? Name { get; set; } = string.Empty;

        public ExchangeMemberRoles Role { get; set; }
        public string RoleDescription { get; set; } = string.Empty;
    }
}