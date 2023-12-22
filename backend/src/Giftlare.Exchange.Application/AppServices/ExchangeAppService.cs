using Giftlare.Core.Domain.Exceptions;
using Giftlare.Exchange.Application.AppServices.Interfaces;
using Giftlare.Exchange.Contracts;
using Giftlare.Exchange.Domain.Entities;
using Giftlare.Exchange.Domain.Repositories;
using System.Text;
using System.Web;

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

            var token = exchange.CreateInvitationToken(adminId);

            var inviteParameters = new StringBuilder()
                .Append("id=").Append(id)
                .Append("&token=").Append(HttpUtility.UrlEncode(token))
                .ToString();

            return inviteParameters;
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
