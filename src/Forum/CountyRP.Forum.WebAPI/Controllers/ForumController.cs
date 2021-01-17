using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using CountyRP.Forum.Domain.Models;
using CountyRP.Forum.WebAPI.ViewModels;
using CountyRP.Forum.WebAPI.Services.Interfaces;

namespace CountyRP.Forum.WebAPI.Controllers
{
    [ApiController]
    [Route("Forum/api/[controller]")]
    public class ForumController : ControllerBase
    {
        private readonly IForumService _forumService;

        public ForumController(IForumService forumService)
        {
            _forumService = forumService;
        }

        /// <summary>
        /// Получение всех форумов
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ForumModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _forumService.GetAllForums());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получить форум с ID id
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ForumModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _forumService.GetForumById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Изменить форум
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ForumModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Edit(int id, [FromBody] ForumViewModel forumViewModel)
        {
            try
            {
                return Ok(await _forumService.Edit(id, forumViewModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Создать форум
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ForumModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] ForumViewModel forumViewModel)
        {
            try
            {
                return Ok(await _forumService.CreateForum(forumViewModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Удалить форум
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _forumService.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получить все форумы с информацией о темах и т.д.
        /// </summary>
        [HttpGet("Full")]
        [ProducesResponseType(typeof(ForumInfoViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetFullAll()
        {
            try
            {
                return Ok(await _forumService.GetForumsInfo());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Statistics")]
        [ProducesResponseType(typeof(StatisticsViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetStatistics()
        {
            try
            {
                return Ok(await _forumService.GetStatistics());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
