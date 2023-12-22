using Giftlare.Exchange.Contracts;

namespace Giftlare.Exchange.Application.AppServices.Interfaces
{
    public interface IExchangeAppService
    {
        void Create(ExchangeCreationDto creationDto, Guid adminId);

        string Invite(Guid id, Guid adminId);
        void AcceptInvite(Guid id, Guid memberId, string token);
    }
}
