using Giftlare.Core.Domain.Exceptions;
using Giftlare.Exchange.Application.AppServices.Interfaces;
using Giftlare.Exchange.Contracts;
using Giftlare.Exchange.Domain.Entities;
using Giftlare.Exchange.Domain.Repositories;

namespace Giftlare.Exchange.Application.AppServices
{
    public class ExchangeAppService : IExchangeAppService
    {
        private readonly IExchangeRepository _repository;

        public ExchangeAppService(IExchangeRepository repository)
        {
            _repository = repository;
        }

        public void Create(ExchangeCreationDto creationDto, Guid adminId)
        {
            var exchange = new ExchangeDomain(creationDto.Name, creationDto.Image, adminId);

            _repository.Add(exchange);
            _repository.CommitChanges();
        }

        public string Invite(Guid id, Guid adminId)
        {
            var exchange = _repository.GetById(id);

            if (exchange == null)
                throw new NotFoundException("Exchange");

            return exchange.CreateInvitationToken(adminId);
        }

        public void AcceptInvite(Guid id, Guid memberId, string token)
        {
            var exchange = _repository.GetById(id);

            if (exchange == null)
                throw new NotFoundException("Exchange");

            exchange.AcceptInvite(memberId, token);

            _repository.Update(exchange);
            _repository.CommitChanges();
        }
    }
}
