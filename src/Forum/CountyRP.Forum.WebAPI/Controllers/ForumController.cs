using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using CountyRP.Forum.Domain.Interfaces;
using CountyRP.Forum.Domain.Models;

namespace CountyRP.Forum.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForumController : ControllerBase
    {
        private readonly IForumRepository _forumRepository;
        private readonly ITopicRepository _topicRepository;

        public ForumController(IForumRepository forumRepository, ITopicRepository topicRepository)
        {
            _forumRepository = forumRepository;
            _topicRepository = topicRepository;
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
                var forums = await _forumRepository.GetAll();

                return Ok(forums);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получение всех тем на форуме id
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Topic), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var topics = await _topicRepository.GetByForumId(id);

                return Ok(topics);
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
                var createdForum = await _forumRepository.CreateForum(forum);

                return Ok(createdForum);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
