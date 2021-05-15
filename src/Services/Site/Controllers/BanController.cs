using CountyRP.Services.Site;
using CountyRP.Services.Site.Converters;
using CountyRP.Services.Site.Models.Api;
using CountyRP.Services.Site.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Site.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BanController : ControllerBase
    {
        private readonly ILogger<BanController> _logger;
        private readonly ISiteRepository _siteRepository;

        public BanController(
            ILogger<BanController> logger,
            ISiteRepository siteRepository
        )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _siteRepository = siteRepository ?? throw new ArgumentNullException(nameof(siteRepository));
        }

        /// <summary>
        /// Создать бан.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiBanDtoOut), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(ApiBanDtoIn apiBanDtoIn)
        {
            apiBanDtoIn.Reason = apiBanDtoIn.Reason?.Trim();

            if (!Regex.IsMatch(apiBanDtoIn.IP, @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$"))
            {
                return BadRequest(ConstantMessages.InvalidIP);
            }
            if (apiBanDtoIn.Reason == null || apiBanDtoIn.Reason.Length < 1 || apiBanDtoIn.Reason.Length > 256)
            {
                return BadRequest(ConstantMessages.BanInvalidReasonLength);
            }
            if (apiBanDtoIn.StartDateTime > apiBanDtoIn.FinishDateTime)
            {
                return BadRequest(ConstantMessages.BanStartMoreThanFinish);
            }

            var bannedUser = await _siteRepository.GetUserByIdAsync(apiBanDtoIn.UserId);
            var adminUser = await _siteRepository.GetUserByIdAsync(apiBanDtoIn.AdminId);
            
            if (bannedUser == null)
            {
                return BadRequest(
                    string.Format(
                        ConstantMessages.BanBannedUserNotFound,
                        apiBanDtoIn.UserId
                    )
                );
            }
            if (adminUser == null)
            {
                return BadRequest(
                    string.Format(
                        ConstantMessages.BanAdminUserNotFound,
                        apiBanDtoIn.AdminId
                    )
                );
            }

            var adminGroup = await _siteRepository.GetGroupAsync(adminUser.GroupId);

            if (adminGroup == null)
            {
                return BadRequest(
                    string.Format(
                        ConstantMessages.BanAdminGroupNotFound,
                        adminUser.GroupId
                    )
                );
            }

            if (adminGroup.MaxBan == 0)
            {
                return BadRequest(
                    string.Format(
                        ConstantMessages.BanAdminGroupCannotBan,
                        adminGroup.Name
                    )
                );
            }

            var differenceTimeSpan = apiBanDtoIn.FinishDateTime - apiBanDtoIn.StartDateTime;

            if (differenceTimeSpan.Hours > adminGroup.MaxBan)
            {
                return BadRequest(
                    string.Format(
                        ConstantMessages.BanInvalidMaxBan,
                        adminGroup.Name,
                        adminGroup.MaxBan
                    )
                );
            }

            var banDtoIn = ApiBanDtoInConverter.ToRepository(apiBanDtoIn);

            var banDtoOut = await _siteRepository.AddBanAsync(banDtoIn);

            return Created(
                string.Empty,
                BanDtoOutConverter.ToApi(banDtoOut)
            );
        }

        /// <summary>
        /// Получить данные бана по ID.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiBanDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var banDtoOut = await _siteRepository.GetBanAsync(id);

            if (banDtoOut == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.BanNotFoundById, id)
                );
            }

            return Ok(
                BanDtoOutConverter.ToApi(banDtoOut)
            );
        }

        /// <summary>
        /// Получить данные бана по ID забаненного пользователя.
        /// </summary>
        [HttpGet("ByUserId/{userId}")]
        [ProducesResponseType(typeof(ApiBanDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var banDtoOut = await _siteRepository.GetBanByUserIdAsync(userId);

            if (banDtoOut == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.BanNotFoundByUserId, userId)
                );
            }

            return Ok(
                BanDtoOutConverter.ToApi(banDtoOut)
            );
        }

        /// <summary>
        /// Получить отфильтрованный список банов.
        /// </summary>
        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(ApiPagedFilterResult<ApiBanDtoOut>), StatusCodes.Status200OK)]
        public async Task<IActionResult> FilterBy([FromQuery] ApiBanFilterDtoIn filter)
        {
            if (filter.Count < 1 || filter.Count > 100)
            {
                return BadRequest(ConstantMessages.InvalidCountItemPerPage);
            }

            if (filter.Page < 1)
            {
                return BadRequest(ConstantMessages.InvalidPageNumber);
            }

            var filterDtoIn = ApiBanFilterDtoInConverter.ToRepository(filter);

            var filteredBans = await _siteRepository.GetBansByFilterAsync(filterDtoIn);

            return Ok(
                PagedFilterResultConverter.ToApi(filteredBans)
            );
        }

        /// <summary>
        /// Изменить данные бана по ID.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiBanDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, ApiBanDtoIn apiBanDtoIn)
        {
            var existedBan = await _siteRepository.GetBanAsync(id);

            if (existedBan == null)
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.BanNotFoundById,
                        id
                    )
                );
            }

            if (!Regex.IsMatch(apiBanDtoIn.IP, @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$"))
            {
                return BadRequest(ConstantMessages.InvalidIP);
            }
            if (apiBanDtoIn.Reason == null || apiBanDtoIn.Reason.Length < 1 || apiBanDtoIn.Reason.Length > 256)
            {
                return BadRequest(ConstantMessages.BanInvalidReasonLength);
            }
            if (apiBanDtoIn.StartDateTime > apiBanDtoIn.FinishDateTime)
            {
                return BadRequest(ConstantMessages.BanStartMoreThanFinish);
            }

            var bannedUser = await _siteRepository.GetUserByIdAsync(apiBanDtoIn.UserId);
            var adminUser = await _siteRepository.GetUserByIdAsync(apiBanDtoIn.AdminId);

            if (bannedUser == null)
            {
                return BadRequest(
                    string.Format(
                        ConstantMessages.BanBannedUserNotFound,
                        bannedUser.Id
                    )
                );
            }
            if (adminUser == null)
            {
                return BadRequest(
                    string.Format(
                        ConstantMessages.BanAdminUserNotFound,
                        adminUser.Id
                    )
                );
            }

            var adminGroup = await _siteRepository.GetGroupAsync(adminUser.GroupId);

            if (adminGroup == null)
            {
                return BadRequest(
                    string.Format(
                        ConstantMessages.BanAdminGroupNotFound,
                        adminUser.GroupId
                    )
                );
            }

            var differenceTimeSpan = apiBanDtoIn.FinishDateTime - apiBanDtoIn.StartDateTime;

            if (differenceTimeSpan.Hours > adminGroup.MaxBan)
            {
                return BadRequest(
                    string.Format(
                        ConstantMessages.BanInvalidMaxBan,
                        adminGroup.Name,
                        adminGroup.MaxBan
                    )
                );
            }

            var banDtoOut = ApiBanDtoInConverter.ToDtoOut(
                source: apiBanDtoIn,
                id: id
            );

            var updatedBanDtoOut = await _siteRepository.UpdateBanAsync(banDtoOut);

            return Ok(
                BanDtoOutConverter.ToApi(updatedBanDtoOut)
            );
        }

        /// <summary>
        /// Удалить пользователя по ID.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiBanDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var existedBan = await _siteRepository.GetBanAsync(id);

            if (existedBan == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.BanNotFoundById, id)
                );
            }

            await _siteRepository.DeleteBanAsync(id);

            return Ok();
        }
    }
}
