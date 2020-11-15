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
                var forums = await _forumService.GetAllForums();

                return Ok(forums);
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
                var forum = await _forumService.GetForumById(id);

                return Ok(forum);
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
                var editedForum = await _forumService.Edit(id, forumViewModel);

                return Ok(editedForum);
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
                var createdForum = await _forumService.CreateForum(forumViewModel);

                return Ok(createdForum);
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
                var forumFull = await _forumService.GetForumsInfo();

                return Ok(forumFull);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
