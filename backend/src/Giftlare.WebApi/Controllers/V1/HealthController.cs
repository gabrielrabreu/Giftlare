using Giftlare.Core.Infra.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Giftlare.WebApi.Controllers.V1
{
    [AllowAnonymous]
    public class HealthController : BaseController
    {
        private readonly IApplicationDbContext _context;

        public HealthController(IApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Health()
        {
            if (_context.CanConnect())
                return NoContent();
            return BadRequest();
        }
    }
}
