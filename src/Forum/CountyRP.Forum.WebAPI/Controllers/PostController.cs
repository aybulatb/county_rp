using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using CountyRP.Forum.Domain.Interfaces;
using CountyRP.Forum.Domain.Models;
using CountyRP.Forum.WebAPI.ViewModels;

namespace CountyRP.Forum.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        /// <summary>
        /// Получение всех постов темы id
        /// </summary>
        [HttpGet("GetPosts/{topicId}")]
        [ProducesResponseType(typeof(Post), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPosts(int topicId)
        {
            try
            {
                var posts = await _postRepository.GetPosts(topicId);

                return Ok(posts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(nameof(CreatePost))]
        [ProducesResponseType(typeof(Post), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePost([FromBody] Post post)
        {
            try
            {
                var createdPost = await _postRepository.Create(post);

                return Ok(createdPost);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(nameof(EditPost))]
        [ProducesResponseType(typeof(Post), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditPost([FromBody] PostViewModel postViewModel)
        {
            try
            {
                var post = new Post
                {
                    Id = postViewModel.Id,
                    Text = postViewModel.Text
                };

                var editedPost = await _postRepository.Edit(post);

                return Ok(editedPost);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeletePost/{id}")]
        [ProducesResponseType(typeof(Post), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                await _postRepository.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
