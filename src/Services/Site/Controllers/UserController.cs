using CountyRP.Services.Site.Models;
using CountyRP.Services.Site.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace Site.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ISiteRepository _siteRepository;

        public UserController(
            ILogger<UserController> logger,
            ISiteRepository siteRepository
        )
        {
            _logger = logger;
            _siteRepository = siteRepository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserDtoOut), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(UserDtoIn userDtoIn)
        {
            var userDtoOut = await _siteRepository.AddUserAsync(userDtoIn);

            return Created(string.Empty, userDtoOut);
        }

        [HttpGet("GetById/{id}")]
        [ProducesResponseType(typeof(UserDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var userDtoOut = await _siteRepository.GetUserByIdAsync(id);

            if (userDtoOut == null)
            {
                return NotFound($"Пользователь с ID {id} не найден");
            }

            return Ok(userDtoOut);
        }

        [HttpGet("GetByLogin/{login}")]
        public async Task<IActionResult> GetByLogin(string login)
        {
            var userDtoOut = await _siteRepository.GetUserByLoginAsync(login);

            if (userDtoOut == null)
            {
                return NotFound();
            }

            return Ok(userDtoOut);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, UserDtoIn userDtoIn)
        {
            var existedUser = await _siteRepository.GetUserByIdAsync(id);

            if (existedUser == null)
            {
                return NotFound();
            }

            var userDtoOut = await _siteRepository.UpdateUserAsync(id, userDtoIn);

            return Ok(userDtoOut);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existedUser = await _siteRepository.GetUserByIdAsync(id);

            if (existedUser == null)
            {
                return NotFound();
            }

            await _siteRepository.DeleteUserAsync(id);

            return Ok();
        }
    }
}
