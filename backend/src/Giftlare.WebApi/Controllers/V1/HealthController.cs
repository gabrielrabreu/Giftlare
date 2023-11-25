using Giftlare.Core.Domain.Security;
using Giftlare.Core.Infra.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Giftlare.WebApi.Controllers.V1
{
    [AllowAnonymous]
    public class HealthController : BaseController
    {
        private readonly IApplicationDbContext _context;
        private readonly ISessionService _sessionService;

        public HealthController(IApplicationDbContext context, ISessionService sessionService)
        {
            _context = context;
            _sessionService = sessionService;
        }

        [HttpGet]
        public IActionResult Health()
        {
            if (_context.CanConnect())
                return Ok(_sessionService.User);
            return BadRequest();
        }
    }
}
