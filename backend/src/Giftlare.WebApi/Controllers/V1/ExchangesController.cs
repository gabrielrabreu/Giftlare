using Giftlare.Core.Domain.Security;
using Giftlare.Exchange.Application.AppQueries.Interfaces;
using Giftlare.Exchange.Application.AppServices.Interfaces;
using Giftlare.Exchange.Contracts;
using Giftlare.Exchange.Infra.Data.Queries.Parameters;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace Giftlare.WebApi.Controllers.V1
{
    public class ExchangesController : BaseController
    {
        private readonly ISessionService _sessionService;
        private readonly IExchangeAppQuery _appQuery;
        private readonly IExchangeAppService _appService;

        public ExchangesController(ISessionService sessionService,
                                   IExchangeAppQuery appQuery,
                                   IExchangeAppService appService)
        {
            _sessionService = sessionService;
            _appQuery = appQuery;
            _appService = appService;
        }

        [HttpGet]
        public IActionResult Paginate([FromQuery] ExchangePagedParameters parameters)
        {
            var memberId = _sessionService.User.Id;
            return Ok(_appQuery.Paginate(memberId, parameters));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var memberId = _sessionService.User.Id;
            return Ok(_appQuery.GetById(memberId, id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] ExchangeCreationDto creationDto)
        {
            _appService.Create(creationDto, _sessionService.User.Id);
            return NoContent();
        }

        [HttpPost("{id}:invite")]
        public IActionResult Invite([FromRoute] Guid id)
        {
            var inviteParameters = _appService.Invite(id, _sessionService.User.Id);
            return Ok(inviteParameters);
        }

        [HttpPost("{id}:accept-invite")]
        public IActionResult AcceptInvite([FromRoute] Guid id, [FromQuery] string token)
        {
            _appService.AcceptInvite(id, _sessionService.User.Id, token);
            return NoContent();
        }
    }
}
