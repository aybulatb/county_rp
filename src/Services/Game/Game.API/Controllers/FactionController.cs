using CountyRP.Services.Game.API.Converters;
using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;
using CountyRP.Services.Game.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FactionController : ControllerBase
    {
        private readonly ILogger<FactionController> _logger;
        private readonly IGameRepository _gameRepository;

        public FactionController(
            ILogger<FactionController> logger,
            IGameRepository gameRepository
        )
        {
            _logger = logger;
            _gameRepository = gameRepository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiFactionDtoOut), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromBody] ApiFactionDtoIn apiFactionDtoIn
        )
        {
            var validatedResult = await ValidateInputCreatedData(apiFactionDtoIn);
            if (validatedResult != null)
            {
                return validatedResult;
            }

            var factionDtoIn = ApiFactionDtoInConverter.ToRepository(apiFactionDtoIn);

            var factionDtoOut = await _gameRepository.AddFactionAsync(factionDtoIn);

            return Created(
                string.Empty,
                FactionDtoOutConverter.ToApi(factionDtoOut)
            );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FactionDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            string id
        )
        {
            var filteredFactions = await _gameRepository.GetFactionsByFilter(
                FactionIdConverter.ToFactionFilterDtoIn(id)
            );

            if (!filteredFactions.Items.Any())
            {
                return NotFound(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.FactionNotFoundById,
                        message: string.Format(
                            ConstantMessages.FactionNotFoundById,
                            id
                        )
                    )
                );
            }

            var faction = filteredFactions.Items.First();

            return Ok(
                FactionDtoOutConverter.ToApi(faction)
            );
        }

        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(ApiPagedFilterResultDtoOut<ApiFactionDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FilterBy(
            [FromQuery] ApiFactionFilterDtoIn apiFactionFilterDtoIn
        )
        {
            if (apiFactionFilterDtoIn.Count < 1)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.InvalidCountItemPerPage,
                        message: ConstantMessages.InvalidCountItemPerPage
                    )
                );
            }
            if (apiFactionFilterDtoIn.Page < 1)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.InvalidPageNumber,
                        message: ConstantMessages.InvalidPageNumber
                    )
                );
            }

            var filter = ApiFactionFilterDtoInConverter.ToRepository(apiFactionFilterDtoIn);

            var factions = await _gameRepository.GetFactionsByFilter(filter);

            return Ok(
                PagedFilterResultDtoOutConverter.ToApi(factions)
            );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiFactionDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(
            string id,
            ApiEditedFactionDtoIn apiEditedFactionDtoIn
        )
        {
            var filteredFactions = await _gameRepository.GetFactionsByFilter(
                FactionIdConverter.ToFactionFilterDtoIn(id)
            );

            if (filteredFactions.AllCount == 0)
            {
                return NotFound(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.FactionNotFoundById,
                        message: string.Format(
                            ConstantMessages.FactionNotFoundById,
                            id
                        )
                    )
                );
            }

            var validatedResult = ValidateInputEditedData(apiEditedFactionDtoIn);
            if (validatedResult != null)
            {
                return validatedResult;
            }

            var factionDtoOut = ApiEditedFactionDtoInConverter.ToDtoOutRepository(
                source: apiEditedFactionDtoIn,
                id: id
            );

            var updatedFactionDtoOut = await _gameRepository.UpdateFactionAsync(factionDtoOut);

            return Ok(
                FactionDtoOutConverter.ToApi(updatedFactionDtoOut)
            );
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            var filter = FactionIdConverter.ToFactionFilterDtoIn(id);

            var filteredFactions = await _gameRepository.GetFactionsByFilter(filter);

            if (!filteredFactions.Items.Any())
            {
                return NotFound(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.FactionNotFoundById,
                        message: string.Format(
                            ConstantMessages.FactionNotFoundById,
                            id
                        )
                    )
                );
            }

            await _gameRepository.DeleteFactionByFilter(filter);

            return Ok();
        }

        private async Task<IActionResult> ValidateInputCreatedData(
            ApiFactionDtoIn apiFactionDtoIn
        )
        {
            apiFactionDtoIn.Name = apiFactionDtoIn.Name?.Trim();
            apiFactionDtoIn.Ranks = apiFactionDtoIn.Ranks
                ?.Select(rank => rank.Trim())
                ?.ToArray();

            if (!Regex.IsMatch(apiFactionDtoIn.Id ?? string.Empty, @"^[0-9a-zA-F_]{3,16}$"))
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.InvalidId,
                        message: ConstantMessages.InvalidId
                    )
                );
            }

            var existedFactionWithId = await _gameRepository.GetFactionsByFilter(
                FactionIdConverter.ToFactionFilterDtoIn(apiFactionDtoIn.Id)
            );

            if (existedFactionWithId.AllCount != 0)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.FactionAlreadyExistsWithId,
                        message: string.Format(
                            ConstantMessages.FactionAlreadyExistsWithId,
                            apiFactionDtoIn.Id
                        )
                    )
                );
            }

            if (apiFactionDtoIn.Name == null || apiFactionDtoIn.Name.Length > 64)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.FactionInvalidNameLength,
                        message: ConstantMessages.FactionInvalidNameLength
                    )
                );
            }

            if (!Regex.IsMatch(apiFactionDtoIn.Name, @"^[\w\s!@#№$%^&?\*()\-=\[\]{}~`]+$"))
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.FactionInvalidName,
                        message: ConstantMessages.FactionInvalidName
                    )
                );
            }

            if (!Regex.IsMatch(apiFactionDtoIn.Color ?? string.Empty, @"^[0-9a-fA-F]{6}$"))
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.InvalidColor,
                        message: ConstantMessages.InvalidColor
                    )
                );
            }

            if (apiFactionDtoIn.Ranks?.Length != 15)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.FactionInvalidRanksCount,
                        message: ConstantMessages.FactionInvalidRanksCount
                    )
                );
            }

            foreach (var rank in apiFactionDtoIn.Ranks)
            {
                if (rank.Length > 32)
                {
                    return BadRequest(
                        new ApiErrorResponseDtoOut(
                            code: ApiErrorCodeDto.FactionInvalidNameLength,
                            message: ConstantMessages.FactionInvalidNameLength
                        )
                    );
                }

                if (!Regex.IsMatch(rank, @"^[\w\s!@#№$%^&?\*()\-=\[\]{}~`]+$"))
                {
                    return BadRequest(
                        new ApiErrorResponseDtoOut(
                            code: ApiErrorCodeDto.FactionInvalidRanksName,
                            message: ConstantMessages.FactionInvalidRanksName
                        )
                    );
                }
            }

            return null;
        }

        private IActionResult ValidateInputEditedData(
            ApiEditedFactionDtoIn apiEditedFactionDtoIn
        )
        {
            apiEditedFactionDtoIn.Name = apiEditedFactionDtoIn.Name?.Trim();
            apiEditedFactionDtoIn.Ranks = apiEditedFactionDtoIn.Ranks
                ?.Select(rank => rank.Trim())
                ?.ToArray();

            if (apiEditedFactionDtoIn.Name == null || apiEditedFactionDtoIn.Name.Length > 64)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.FactionInvalidNameLength,
                        message: ConstantMessages.FactionInvalidNameLength
                    )
                );
            }

            if (!Regex.IsMatch(apiEditedFactionDtoIn.Name, @"^[\w\s!@#№$%^&?\*()\-=\[\]{}~`]+$"))
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.FactionInvalidName,
                        message: ConstantMessages.FactionInvalidName
                    )
                );
            }

            if (!Regex.IsMatch(apiEditedFactionDtoIn.Color ?? string.Empty, @"^[0-9a-fA-F]{6}$"))
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.InvalidColor,
                        message: ConstantMessages.InvalidColor
                    )
                );
            }

            if (apiEditedFactionDtoIn.Ranks?.Length != 15)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.FactionInvalidRanksCount,
                        message: ConstantMessages.FactionInvalidRanksCount
                    )
                );
            }

            foreach (var rank in apiEditedFactionDtoIn.Ranks)
            {
                if (rank.Length > 32)
                {
                    return BadRequest(
                        new ApiErrorResponseDtoOut(
                            code: ApiErrorCodeDto.FactionInvalidNameLength,
                            message: ConstantMessages.FactionInvalidNameLength
                        )
                    );
                }

                if (!Regex.IsMatch(rank, @"^[\w\s!@#№$%^&?\*()\-=\[\]{}~`]+$"))
                {
                    return BadRequest(
                        new ApiErrorResponseDtoOut(
                            code: ApiErrorCodeDto.FactionInvalidRanksName,
                            message: ConstantMessages.FactionInvalidRanksName
                        )
                    );
                }
            }

            return null;
        }
    }
}
