using Giftlare.Core.Domain.Security;
using Giftlare.Enums;
using Giftlare.Main.Application.AppServices.Interfaces;
using Giftlare.Main.Contracts;
using Giftlare.Main.Domain.Entities;
using Giftlare.Main.Domain.Repositories;

namespace Giftlare.Main.Application.AppServices
{
    public class GatheringAppService : IGatheringAppService
    {
        private readonly ISessionService _sessionService;
        private readonly IGatheringRepository _repository;

        public GatheringAppService(ISessionService sessionService,
                                   IGatheringRepository repository)
        {
            _sessionService = sessionService;
            _repository = repository;
        }

        public void Create(GatheringForCreationDto forCreationDto)
        {
            var gathering = new GatheringDomain(forCreationDto.Name);
            gathering.AddMember(_sessionService.User.Id, GatheringMemberRoles.Admin);

            _repository.Add(gathering);
            _repository.CommitChanges();
        }
    }
}
