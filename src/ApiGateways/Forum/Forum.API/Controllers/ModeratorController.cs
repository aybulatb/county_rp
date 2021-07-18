using CountyRP.ApiGateways.Forum.API.Converters;
using CountyRP.ApiGateways.Forum.API.Models;
using CountyRP.ApiGateways.Forum.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.Forum.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModeratorController : ControllerBase
    {
        private readonly IModeratorService _moderatorService;

        public ModeratorController(IModeratorService moderatorService)
        {
            _moderatorService = moderatorService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ApiModeratorDtoIn apiModeratorDtoIn)
        {
            var moderatorDtoIn = ApiModeratorDtoInConverter.ToService(apiModeratorDtoIn);

            var response = await _moderatorService.Create(moderatorDtoIn);

            return Created(
                string.Empty,
                response);
        }
    }
}
