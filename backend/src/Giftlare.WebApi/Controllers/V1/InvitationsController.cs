using Giftlare.Main.Application.AppServices.Interfaces;
using Giftlare.Main.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Giftlare.WebApi.Controllers.V1
{
    public class InvitationsController : BaseController
    {
        private readonly IInvitationAppService _appService;

        public InvitationsController(IInvitationAppService appService)
        {
            _appService = appService;
        }

        [HttpPost("create/{id}")]
        public IActionResult CreateInvitationToken([FromRoute] Guid id)
        {
            var invitation = _appService.CreateInvitation(id);
            return Ok(invitation);
        }

        [HttpPost("accept/{id}")]
        public IActionResult AcceptInvitation([FromRoute] Guid id, [FromBody] AcceptInvitationDto acceptInvitationDto)
        {
            acceptInvitationDto.GatheringId = id;
            _appService.AcceptInvitation(acceptInvitationDto);
            return NoContent();
        }
    }
}
