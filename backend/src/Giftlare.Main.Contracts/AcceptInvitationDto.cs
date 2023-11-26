namespace Giftlare.Main.Contracts
{
    public class AcceptInvitationDto
    {
        public string InvitationToken { get; set; } = string.Empty;
        public Guid GatheringId { get; set; }
    }
}
