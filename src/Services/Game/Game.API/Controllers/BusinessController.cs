using CountyRP.Services.Game.API.Converters;
using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;
using CountyRP.Services.Game.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinessController : ControllerBase
    {
        private readonly ILogger<BusinessController> _logger;
        private readonly IGameRepository _gameRepository;

        public BusinessController(
            ILogger<BusinessController> logger,
            IGameRepository gameRepository
        )
        {
            _logger = logger;
            _gameRepository = gameRepository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiBusinessDtoOut), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromBody] ApiBusinessDtoIn apiBusinessDtoIn
        )
        {
            //var validatedResult = await ValidateInputCreatedOrEditedData(apiBusinessDtoIn);
            //if (validatedResult != null)
            //{
            //    return validatedResult;
            //}

            var businessDtoIn = ApiBusinessDtoInConverter.ToRepository(apiBusinessDtoIn);

            var businessDtoOut = await _gameRepository.AddBusinessAsync(businessDtoIn);

            return Created(
                string.Empty,
                BusinessDtoOutConverter.ToApi(businessDtoOut)
            );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BusinessDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            int id
        )
        {
            var filteredBusinesss = await _gameRepository.GetBusinessesByFilter(
                BusinessIdConverter.ToBusinessFilterDtoIn(id)
            );

            if (!filteredBusinesss.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.BusinessNotFoundById,
                        id
                    )
                );
            }

            var business = filteredBusinesss.Items.First();

            return Ok(
                BusinessDtoOutConverter.ToApi(business)
            );
        }

        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(ApiPagedFilterResultDtoOut<ApiBusinessDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FilterBy(
            [FromQuery] ApiBusinessFilterDtoIn apiBusinessFilterDtoIn
        )
        {
            if (apiBusinessFilterDtoIn.Count < 1)
            {
                return BadRequest(
                    ConstantMessages.InvalidCountItemPerPage
                );
            }
            if (apiBusinessFilterDtoIn.Page < 1)
            {
                return BadRequest(
                    ConstantMessages.InvalidPageNumber
                );
            }

            var filter = ApiBusinessFilterDtoInConverter.ToRepository(apiBusinessFilterDtoIn);

            var businesses = await _gameRepository.GetBusinessesByFilter(filter);

            return Ok(
                PagedFilterResultDtoOutConverter.ToApi(businesses)
            );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiBusinessDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(
            int id,
            ApiBusinessDtoIn apiBusinessDtoIn
        )
        {
            var filteredBusinesss = await _gameRepository.GetBusinessesByFilter(
                BusinessIdConverter.ToBusinessFilterDtoIn(id)
            );

            if (filteredBusinesss.AllCount == 0)
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.BusinessNotFoundById,
                        id
                    )
                );
            }

            //var validatedResult = await ValidateInputCreatedOrEditedData(apiBusinessDtoIn);
            //if (validatedResult != null)
            //{
            //    return validatedResult;
            //}

            var businessDtoOut = ApiBusinessDtoInConverter.ToDtoOutRepository(
                source: apiBusinessDtoIn,
                id: id
            );

            var updatedBusinessDtoOut = await _gameRepository.UpdateBusinessAsync(businessDtoOut);

            return Ok(
                BusinessDtoOutConverter.ToApi(updatedBusinessDtoOut)
            );
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var filter = BusinessIdConverter.ToBusinessFilterDtoIn(id);

            var filteredBusinesss = await _gameRepository.GetBusinessesByFilter(filter);

            if (!filteredBusinesss.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.BusinessNotFoundById,
                        id
                    )
                );
            }

            await _gameRepository.DeleteBusinessesByFilter(filter);

            return Ok();
        }
    }
}
