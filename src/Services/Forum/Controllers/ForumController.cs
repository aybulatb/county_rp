using CountyRP.Services.Forum.Converters;
using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Models.Api;
using CountyRP.Services.Forum.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForumController : ControllerBase
    {
        private readonly ILogger<ForumController> _logger;
        private readonly IForumRepository _forumRepository;

        public ForumController(
            ILogger<ForumController> logger,
            IForumRepository forumRepository
        )
        {
            _logger = logger;
            _forumRepository = forumRepository;
        }

        /// <summary>
        /// Создать форум.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiForumDtoOut), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] ApiForumDtoIn apiForumDtoIn)
        {
            if (apiForumDtoIn.Name == null || apiForumDtoIn.Name.Length < 1 || apiForumDtoIn.Name.Length > 96)
            {
                return BadRequest(ConstantMessages.ForumInvalidNameLength);
            }

            var forumDtoIn = ApiForumDtoInConverter.ToRepository(apiForumDtoIn);

            var forumDtoOut = await _forumRepository.CreateForumAsync(forumDtoIn);

            return Created(
                string.Empty,
                ForumDtoOutConverter.ToApi(forumDtoOut)
            );
        }

        /// <summary>
        /// Получить все форумы.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApiForumDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var forumsDtoOut = await _forumRepository.GetForumsAsync();

            return Ok(
                forumsDtoOut.Select(ForumDtoOutConverter.ToApi)
            );
        }

        /// <summary>
        /// Получить данные форума по ID.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiForumDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var forumDtoOut = await _forumRepository.GetForumByIdAsync(id);

            if (forumDtoOut == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.ForumNotFoundById, id)
                );
            }

            return Ok(
                ForumDtoOutConverter.ToApi(forumDtoOut)
            );
        }

        /// <summary>
        /// Получить отфильтрованный список форумов.
        /// </summary>
        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(PagedFilterResult<ApiForumDtoOut>), StatusCodes.Status200OK)]
        public async Task<IActionResult> FilterBy([FromQuery] ApiForumFilterDtoIn filter)
        {
            if (filter.Count < 1 || filter.Count > 100)
            {
                return BadRequest(ConstantMessages.InvalidCountItemPerPage);
            }

            if (filter.Page < 1)
            {
                return BadRequest(ConstantMessages.InvalidPageNumber);
            }

            var filterDtoIn = ApiForumFilterDtoInConverter.ToRepository(filter);

            var filteredForums = await _forumRepository.GetForumsByFilterAsync(filterDtoIn);

            return Ok(
                PagedFilterResultConverter.ToApi(filteredForums)
            );
        }

        /// <summary>
        /// Изменить данные форума по ID
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiForumDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, [FromBody] ApiForumDtoIn apiForumDtoIn)
        {
            var existedForum = await _forumRepository.GetForumByIdAsync(id);

            if (existedForum == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.ForumNotFoundById, id)
                );
            }

            if (apiForumDtoIn.Name == null || apiForumDtoIn.Name.Length < 1 || apiForumDtoIn.Name.Length > 96)
            {
                return BadRequest(ConstantMessages.ForumInvalidNameLength);
            }


            var forumDtoIn = ApiForumDtoInConverter.ToRepository(apiForumDtoIn);

            var forumDtoOut = ForumDtoInConverter.ToDtoOut(
                source: forumDtoIn,
                id: id
            );

            var updatedForumDtoOut = await _forumRepository.UpdateForumAsync(forumDtoOut);

            return Ok(
                ForumDtoOutConverter.ToApi(updatedForumDtoOut)
            );
        }

        /// <summary>
        /// Удалить форум по ID.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var existedForum = await _forumRepository.GetForumByIdAsync(id);

            if (existedForum == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.ForumNotFoundById, id)
                );
            }

            await _forumRepository.DeleteForumAsync(id);

            return Ok();
        }
    }
}
