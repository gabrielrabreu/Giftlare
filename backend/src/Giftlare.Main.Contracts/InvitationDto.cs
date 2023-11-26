namespace Giftlare.Main.Contracts
{
    public class InvitationDto
    {
        public string InvitationToken { get; set; } = string.Empty;
        public Guid GatheringId { get; set; }
    }
}
