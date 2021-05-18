using CountyRP.Services.Forum.Converters;
using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Models.Api;
using CountyRP.Services.Forum.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Controllers
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
            if (filter.Count < 1 || filter.Count > 100)
            {
                return BadRequest(ConstantMessages.InvalidCountItemPerPage);
            }

            if (filter.Page < 1)
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
        /// Изменить данные модератора по ID
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiModeratorDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
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

            var moderatorDtoIn = ApiModeratorDtoInConverter.ToRepository(apiModeratorDtoIn);

            var moderatorDtoOut = ModeratorDtoInConverter.ToDtoOut(
                source: moderatorDtoIn,
                id: id
            );

            var updatedModeratorDtoOut = await _forumRepository.UpdateModeratorAsync(moderatorDtoOut);

            return Ok(
                ModeratorDtoOutConverter.ToApi(updatedModeratorDtoOut)
            );
        }

        /// <summary>
        /// Удалить тему по ID.
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

            await _forumRepository.DeleteModeratorByIdAsync(id);

            return Ok();
        }
    }
}
