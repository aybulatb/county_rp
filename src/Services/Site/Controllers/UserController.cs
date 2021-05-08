using CountyRP.Services.Site.Converters;
using CountyRP.Services.Site.Models;
using CountyRP.Services.Site.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using CountyRP.Services.Site.Models.Api;
using CountyRP.Services.Site;
using System.Text.RegularExpressions;

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
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(UserDtoIn userDtoIn)
        {
            if (userDtoIn.Login == null || userDtoIn.Login.Length < 3 || userDtoIn.Login.Length > 32)
            {
                return BadRequest(ConstantMessages.UserInvalidLoginLength);
            }
            if (!Regex.IsMatch(userDtoIn.Login, @"^([0-9a-zA-Z]{3,32}|[0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31}|[0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31})$"))
            {
                return BadRequest(ConstantMessages.UserInvalidLogin);
            }
            if (userDtoIn.Password == null || userDtoIn.Password.Length < 8 || userDtoIn.Password.Length > 64)
            {
                return BadRequest(ConstantMessages.UserInvalidPasswordLength);
            }
            if (!Regex.IsMatch(userDtoIn.Password, @"^[0-9a-zA-Z!@#№$%^&?*()\-=\[\]{}~`]{8,64}$"))
            {
                return BadRequest(ConstantMessages.UserInvalidPassword);
            }

            var existedUser = await _siteRepository.GetUserByLoginAsync(userDtoIn.Login);

            if (existedUser != null)
            {
                return BadRequest(ConstantMessages.UserAlreadyExistedWithLogin);
            }

            var userDtoOut = await _siteRepository.AddUserAsync(userDtoIn);

            return Created(
                string.Empty,
                UserDtoOutConverter.ToApi(userDtoOut)
            );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var userDtoOut = await _siteRepository.GetUserByIdAsync(id);

            if (userDtoOut == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.UserNotFoundById, id)
                );
            }

            return Ok(
                UserDtoOutConverter.ToApi(userDtoOut)
            );
        }

        [HttpGet("ByLogin/{login}")]
        [ProducesResponseType(typeof(UserDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByLogin(string login)
        {
            var userDtoOut = await _siteRepository.GetUserByLoginAsync(login);

            if (userDtoOut == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.UserNotFoundByLogin, login)
                );
            }

            return Ok(
                UserDtoOutConverter.ToApi(userDtoOut)
            );
        }

        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(PagedFilterResult<UserDtoOut>), StatusCodes.Status200OK)]
        public async Task<IActionResult> FilterBy([FromQuery] ApiUserFilterDtoIn filter)
        {
            var filterDtoIn = ApiUserFilterDtoInConverter.ToRepository(filter);

            var filteredUsers = await _siteRepository.GetUsersByFilterAsync(filterDtoIn);

            return Ok(
                PagedFilterResultConverter.ToApi(filteredUsers)
            );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UserDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, UserDtoIn userDtoIn)
        {
            var existedUser = await _siteRepository.GetUserByIdAsync(id);

            if (existedUser == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.UserNotFoundById, id)
                );
            }

            if (userDtoIn.Login == null || userDtoIn.Login.Length < 3 || userDtoIn.Login.Length > 32)
            {
                return BadRequest(ConstantMessages.UserInvalidLoginLength);
            }
            if (!Regex.IsMatch(userDtoIn.Login, @"^([0-9a-zA-Z]{3,32}|[0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31}|[0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31})$"))
            {
                return BadRequest(ConstantMessages.UserInvalidLogin);
            }
            if (userDtoIn.Password == null || userDtoIn.Password.Length < 8 || userDtoIn.Password.Length > 64)
            {
                return BadRequest(ConstantMessages.UserInvalidPasswordLength);
            }
            if (!Regex.IsMatch(userDtoIn.Password, @"^[0-9a-zA-Z!@#№$%^&?*()\-=\[\]{}~`]{8,64}$"))
            {
                return BadRequest(ConstantMessages.UserInvalidPassword);
            }

            var existedUserWithLogin = await _siteRepository.GetUserByLoginAsync(userDtoIn.Login);

            if (existedUserWithLogin != null && existedUser.Id != existedUserWithLogin.Id)
            {
                return BadRequest(ConstantMessages.UserAlreadyExistedWithLogin);
            }

            var userDtoOut = UserDtoInConverter.ToDtoOut(
                source: userDtoIn,
                id: id
            );

            var updatedUserDtoOut = await _siteRepository.UpdateUserAsync(userDtoOut);

            return Ok(
                UserDtoOutConverter.ToApi(updatedUserDtoOut)
            );
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UserDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var existedUser = await _siteRepository.GetUserByIdAsync(id);

            if (existedUser == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.UserNotFoundById, id)
                );
            }

            await _siteRepository.DeleteUserAsync(id);

            return Ok();
        }
    }
}
