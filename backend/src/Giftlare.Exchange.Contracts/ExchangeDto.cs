namespace Giftlare.Exchange.Contracts
{
    public class ExchangeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ExchangeMemberDto> Members { get; set; } = new();
    }
}