using CountyRP.ApiGateways.Forum.API.Converters;
using CountyRP.ApiGateways.Forum.API.Models;
using CountyRP.ApiGateways.Forum.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.Forum.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForumController : ControllerBase
    {
        private readonly IForumService _forumService;

        public ForumController(IForumService forumService)
        {
            _forumService = forumService ?? throw new ArgumentNullException(nameof(forumService));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ApiForumDtoIn apiForumDtoIn)
        {
            var forumDtoIn = ApiForumDtoInConverter.ToService(apiForumDtoIn);

            var response = await _forumService.Create(forumDtoIn);

            return Created(
                string.Empty,
                response);
        }
    }
}
