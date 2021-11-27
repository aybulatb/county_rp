using CountyRP.Services.Forum.API.Converters;
using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;
using CountyRP.Services.Forum.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModeratorController : ControllerBase
    {
        private readonly ILogger<ModeratorController> _logger;
        private readonly IForumRepository _forumRepository;

        public ModeratorController(
            ILogger<ModeratorController> logger,
            IForumRepository forumRepository
        )
        {
            _logger = logger;
            _forumRepository = forumRepository;
        }

        /// <summary>
        /// Создать модератора
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiModeratorDtoOut), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] ApiModeratorDtoIn apiModeratorDtoIn)
        {
            var moderatorDtoIn = ApiModeratorDtoInConverter.ToRepository(apiModeratorDtoIn);

            var moderatorDtoOut = await _forumRepository.AddModeratorAsync(moderatorDtoIn);

            return Created(
                string.Empty,
                ModeratorDtoOutConverter.ToApi(moderatorDtoOut)
            );
        }

        /// <summary>
        /// Массово создать модераторов.
        /// </summary>
        [HttpPost("Massively")]
        [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> MassivelyCreate([FromBody] IEnumerable<ApiModeratorDtoIn> apiModeratorsDtoIn)
        {
            var moderatorsDtoIn = apiModeratorsDtoIn
                .Select(ApiModeratorDtoInConverter.ToRepository);

            await _forumRepository.AddModeratorsAsync(moderatorsDtoIn);

            return Created(
                string.Empty,
                null
            );
        }

        /// <summary>
        /// Получить данные модератора по ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiModeratorDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var moderatorDtoOut = await _forumRepository.GetModeratorByIdAsync(id);

            if (moderatorDtoOut == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.ModeratorNotFoundById, id)
                );
            }

            return Ok(
                ModeratorDtoOutConverter.ToApi(moderatorDtoOut)
            );
        }

        /// <summary>
        /// Получить отфильтрованный список модераторов
        /// </summary>
        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(PagedFilterResult<ApiModeratorDtoOut>), StatusCodes.Status200OK)]
        public async Task<IActionResult> FilterBy([FromQuery] ApiModeratorFilterDtoIn filter)
        {
            if (filter.Count.HasValue && (filter.Count < 1 || filter.Count > 100))
            {
                return BadRequest(ConstantMessages.CountItemPerPageMoreThan100);
            }

            if (filter.Page.HasValue && filter.Page < 1)
            {
                return BadRequest(ConstantMessages.InvalidPageNumber);
            }

            var filterDtoIn = ApiModeratorFilterDtoInConverter.ToRepository(filter);

            var filteredModerators = await _forumRepository.GetModeratorByFilterAsync(filterDtoIn);

            return Ok(
                PagedFilterResultConverter.ToApi(filteredModerators)
            );
        }

        /// <summary>
        /// Изменить данные модератора по ID.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, [FromBody] ApiModeratorDtoIn apiModeratorDtoIn)
        {
            var existedModerator = await _forumRepository.GetModeratorByIdAsync(id);

            if (existedModerator == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.ModeratorNotFoundById, id)
                );
            }

            var moderatorDtoOut = ApiModeratorDtoInConverter.ToDtoOut(
                source: apiModeratorDtoIn,
                id: id
            );

            await _forumRepository.UpdateModeratorAsync(moderatorDtoOut);

            return NoContent();
        }

        /// <summary>
        /// Изменить данные модератора по ID.
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> MassivelyEdit([FromBody] IEnumerable<ApiModeratorDtoOut> apiModeratorDtoOut)
        {
            var moderatorsDtoOut = apiModeratorDtoOut
                .Select(ApiModeratorDtoOutConverter.ToRepository);

            await _forumRepository.UpdateModeratorsAsync(moderatorsDtoOut);

            return NoContent();
        }

        /// <summary>
        /// Удалить модератора по ID.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var existedModerator = await _forumRepository.GetModeratorByIdAsync(id);

            if (existedModerator == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.ModeratorNotFoundById, id)
                );
            }

            await _forumRepository.DeleteModeratorAsync(id);

            return Ok();
        }

        /// <summary>
        /// Удалить модераторов по списку ID.
        /// </summary>
        [HttpDelete("ByFilter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteByFilter([FromBody] ApiModeratorFilterDtoIn apiModeratorFilterDtoIn)
        {
            var moderatoFilterDtoIn = ApiModeratorFilterDtoInConverter.ToRepository(apiModeratorFilterDtoIn);

            await _forumRepository.DeleteModeratorsByFilterAsync(moderatoFilterDtoIn);

            return Ok();
        }
    }
}
