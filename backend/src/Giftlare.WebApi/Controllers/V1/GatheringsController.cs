using Giftlare.Main.Application.AppQueries.Interfaces;
using Giftlare.Main.Application.AppServices.Interfaces;
using Giftlare.Main.Contracts;
using Giftlare.Main.Infra.Repository.Queries.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace Giftlare.WebApi.Controllers.V1
{
    public class GatheringsController : BaseController
    {
        private readonly IGatheringAppQuery _appQuery;
        private readonly IGatheringAppService _appServices;

        public GatheringsController(IGatheringAppQuery appQuery,
                                    IGatheringAppService appServices)
        {
            _appQuery = appQuery;
            _appServices = appServices;
        }

        [HttpGet]
        public IActionResult Paginate([FromQuery] GatheringParameters parameters)
        {
            return Ok(_appQuery.Paginate(parameters));
        }

        [HttpPost]
        public IActionResult Create([FromBody] GatheringForCreationDto forCreationDto)
        {
            _appServices.Create(forCreationDto);
            return NoContent();
        }
    }
}
