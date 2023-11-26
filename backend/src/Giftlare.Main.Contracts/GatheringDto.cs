namespace Giftlare.Main.Contracts
{
    public class GatheringDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<GatheringMemberDto> Members { get; set; } = new List<GatheringMemberDto>();
    }
}
