using CountyRP.Services.Site.API.Converters;
using CountyRP.Services.Site.API.Models.Api;
using CountyRP.Services.Site.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CountyRP.Services.Site.API.Controllers
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
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _siteRepository = siteRepository ?? throw new ArgumentNullException(nameof(siteRepository));
        }

        /// <summary>
        /// Создать пользователя.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiUserDtoOut), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(ApiUserDtoIn apiUserDtoIn)
        {
            if (apiUserDtoIn.Login == null || apiUserDtoIn.Login.Length < 3 || apiUserDtoIn.Login.Length > 32)
            {
                return BadRequest(ConstantMessages.UserInvalidLoginLength);
            }
            if (!Regex.IsMatch(apiUserDtoIn.Login, @"^([0-9a-zA-Z]{3,32}|[0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31}|[0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31})$"))
            {
                return BadRequest(ConstantMessages.UserInvalidLogin);
            }
            if (apiUserDtoIn.Password == null || apiUserDtoIn.Password.Length < 8 || apiUserDtoIn.Password.Length > 64)
            {
                return BadRequest(ConstantMessages.UserInvalidPasswordLength);
            }
            if (!Regex.IsMatch(apiUserDtoIn.Password, @"^[0-9a-zA-Z!@#№$%^&?*()\-=\[\]{}~`]{8,64}$"))
            {
                return BadRequest(ConstantMessages.UserInvalidPassword);
            }

            var existedUser = await _siteRepository.GetUserByLoginAsync(apiUserDtoIn.Login);

            if (existedUser != null)
            {
                return BadRequest(ConstantMessages.UserAlreadyExistedWithLogin);
            }

            var userDtoIn = ApiUserDtoInConverter.ToRepository(apiUserDtoIn);

            var userDtoOut = await _siteRepository.AddUserAsync(userDtoIn);

            return Created(
                string.Empty,
                UserDtoOutConverter.ToApi(userDtoOut)
            );
        }

        /// <summary>
        /// Получить данные пользователя по ID.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiUserDtoOut), StatusCodes.Status200OK)]
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

        /// <summary>
        /// Получить данные пользователя по логину.
        /// </summary>
        [HttpGet("ByLogin/{login}")]
        [ProducesResponseType(typeof(ApiUserDtoOut), StatusCodes.Status200OK)]
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

        /// <summary>
        /// Аутентифицировать пользователя.
        /// </summary>
        [HttpPost("Authenticate")]
        [ProducesResponseType(typeof(ApiUserDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Authenticate(string login, string password)
        {
            var userDtoOut = await _siteRepository.AuthenticateAsync(login, password);

            if (userDtoOut == null)
            {
                return NotFound(
                    ConstantMessages.UserInvalidAuthentication
                );
            }

            return Ok(
                UserDtoOutConverter.ToApi(userDtoOut)
            );
        }

        /// <summary>
        /// Получить отфильтрованный список пользователей.
        /// </summary>
        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(ApiPagedFilterResult<ApiUserDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FilterBy([FromQuery] ApiUserFilterDtoIn filter)
        {
            if (filter.Count < 1 || filter.Count > 100)
            {
                return BadRequest(ConstantMessages.CountItemPerPageMoreThan100);
            }

            if (filter.Page < 1)
            {
                return BadRequest(ConstantMessages.InvalidPageNumber);
            }

            var filterDtoIn = ApiUserFilterDtoInConverter.ToRepository(filter);

            var filteredUsers = await _siteRepository.GetUsersByFilterAsync(filterDtoIn);

            return Ok(
                PagedFilterResultConverter.ToApi(filteredUsers)
            );
        }

        /// <summary>
        /// Изменить данные пользователя по ID.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiUserDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, ApiUserDtoIn apiUserDtoIn)
        {
            var existedUser = await _siteRepository.GetUserByIdAsync(id);

            if (existedUser == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.UserNotFoundById, id)
                );
            }

            if (apiUserDtoIn.Login == null || apiUserDtoIn.Login.Length < 3 || apiUserDtoIn.Login.Length > 32)
            {
                return BadRequest(ConstantMessages.UserInvalidLoginLength);
            }
            if (!Regex.IsMatch(apiUserDtoIn.Login, @"^([0-9a-zA-Z]{3,32}|[0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31}|[0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31})$"))
            {
                return BadRequest(ConstantMessages.UserInvalidLogin);
            }
            if (apiUserDtoIn.Password == null || apiUserDtoIn.Password.Length < 8 || apiUserDtoIn.Password.Length > 64)
            {
                return BadRequest(ConstantMessages.UserInvalidPasswordLength);
            }
            if (!Regex.IsMatch(apiUserDtoIn.Password, @"^[0-9a-zA-Z!@#№$%^&?*()\-=\[\]{}~`]{8,64}$"))
            {
                return BadRequest(ConstantMessages.UserInvalidPassword);
            }

            var existedUserWithLogin = await _siteRepository.GetUserByLoginAsync(apiUserDtoIn.Login);

            if (existedUserWithLogin != null && existedUser.Id != existedUserWithLogin.Id)
            {
                return BadRequest(ConstantMessages.UserAlreadyExistedWithLogin);
            }

            var userDtoOut = ApiUserDtoInConverter.ToDtoOut(
                source: apiUserDtoIn,
                existedUser: existedUser
            );

            var updatedUserDtoOut = await _siteRepository.UpdateUserAsync(userDtoOut);

            return Ok(
                UserDtoOutConverter.ToApi(updatedUserDtoOut)
            );
        }

        /// <summary>
        /// Удалить пользователя по ID.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiUserDtoOut), StatusCodes.Status200OK)]
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
