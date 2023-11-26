using Giftlare.Core.Domain.Exceptions;
using Giftlare.Core.Domain.Security;
using Giftlare.Main.Application.AppServices.Interfaces;
using Giftlare.Main.Contracts;
using Giftlare.Main.Domain.Repositories;

namespace Giftlare.Main.Application.AppServices
{
    public class InvitationAppService : IInvitationAppService
    {
        private readonly ISessionService _sessionService;
        private readonly IGatheringRepository _repository;

        public InvitationAppService(ISessionService sessionService, 
                                    IGatheringRepository repository)
        {
            _sessionService = sessionService;
            _repository = repository;
        }

        public InvitationDto CreateInvitation(Guid gatheringId)
        {
            var gathering = _repository.GetById(gatheringId);

            if (gathering == null)
                throw new NotFoundException("Gathering");

            var invitationToken = gathering.CreateInvitationToken(_sessionService.User.Id);

            return new InvitationDto()
            {
                InvitationToken = invitationToken,
                GatheringId = gatheringId
            };
        }

        public void AcceptInvitation(AcceptInvitationDto acceptInvitationDto)
        {
            var gathering = _repository.GetById(acceptInvitationDto.GatheringId);

            if (gathering == null)
                throw new NotFoundException("Gathering");

            gathering.AcceptInvitation(_sessionService.User.Id, acceptInvitationDto.InvitationToken);

            _repository.Update(gathering);
            _repository.CommitChanges();
        }
    }
}
