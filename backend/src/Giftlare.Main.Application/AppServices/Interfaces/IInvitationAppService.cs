using Giftlare.Main.Contracts;

namespace Giftlare.Main.Application.AppServices.Interfaces
{
    public interface IInvitationAppService
    {
        InvitationDto CreateInvitation(Guid gatheringId);
        void AcceptInvitation(AcceptInvitationDto acceptInvitationDto);
    }
}
