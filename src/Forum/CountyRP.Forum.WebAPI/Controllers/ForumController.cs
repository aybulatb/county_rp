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
    [Route("[controller]")]
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
        [HttpGet(nameof(GetAll))]
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
        /// Создание форума
        /// </summary>
        [HttpPost(nameof(CreateForum))]
        [ProducesResponseType(typeof(ForumModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateForum([FromBody] ForumModel forum)
        {
            try
            {
                var createdForum = await _forumService.CreateForum(forum);

                return Ok(createdForum);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet(nameof(GetForumsInfo))]
        [ProducesResponseType(typeof(ForumInfoViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetForumsInfo()
        {
            try
            {
                var forumInfos = await _forumService.GetForumsInfo();

                return Ok(forumInfos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
