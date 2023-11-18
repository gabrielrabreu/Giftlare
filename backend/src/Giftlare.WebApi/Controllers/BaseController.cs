using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Giftlare.WebApi.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("v{version:apiVersion}/[controller]")]
    public abstract class BaseController : ControllerBase
    {
    }
}
