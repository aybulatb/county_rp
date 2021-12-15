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
    public class GroupController : ControllerBase
    {
        private readonly ILogger<GroupController> _logger;
        private ISiteRepository _siteRepository;

        public GroupController(
            ILogger<GroupController> logger,
            ISiteRepository siteRepository
        )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _siteRepository = siteRepository ?? throw new ArgumentNullException(nameof(siteRepository));
        }

        /// <summary>
        /// Создать группу пользователей.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiGroupDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(ApiGroupDtoIn apiGroupDtoIn)
        {
            if (apiGroupDtoIn.Name == null || apiGroupDtoIn.Name.Length < 3 || apiGroupDtoIn.Name.Length > 32)
            {
                return BadRequest(ConstantMessages.GroupInvalidNameLength);
            }
            if (!Regex.IsMatch(apiGroupDtoIn.Name, @"^[0-9a-zA-Zа-яА-Я!@#№$%^&?*()\-_=\[\]{}~`\s]{3,32}$"))
            {
                return BadRequest(ConstantMessages.GroupInvalidName);
            }
            if (apiGroupDtoIn.Color == null || !Regex.IsMatch(apiGroupDtoIn.Color, @"^[0-9a-fA-F]{6}$"))
            {
                return BadRequest(ConstantMessages.GroupInvalidColor);
            }
            if (apiGroupDtoIn.MaxBan < 0 || apiGroupDtoIn.MaxBan > int.MaxValue)
            {
                return BadRequest(
                    string.Format(
                        ConstantMessages.GroupInvalidMaxBan,
                        0,
                        int.MaxValue
                    )
                );
            }
            if (apiGroupDtoIn.BanGroupIds == null)
            {
                apiGroupDtoIn = apiGroupDtoIn with { BanGroupIds = new int[0] };
            }
            foreach (var banGroupId in apiGroupDtoIn.BanGroupIds)
            {
                var existedGroupWithBanGroupId = await _siteRepository.GetGroupAsync(banGroupId);

                if (existedGroupWithBanGroupId == null)
                {
                    return BadRequest(
                        string.Format(
                            ConstantMessages.GroupNotFoundWithBanGroupId,
                            banGroupId
                        )
                    );
                }
            }

            var groupDtoIn = ApiGroupDtoInConverter.ToRepository(apiGroupDtoIn);

            var groupDtoOut = await _siteRepository.AddGroupAsync(groupDtoIn);

            return Ok(
                GroupDtoOutConverter.ToApi(groupDtoOut)
            );
        }

        /// <summary>
        /// Получить данные группы пользователей по ID.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiGroupDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var groupDtoOut = await _siteRepository.GetGroupAsync(id);

            if (groupDtoOut == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.GroupNotFoundById, id)
                );
            }

            return Ok(
                GroupDtoOutConverter.ToApi(groupDtoOut)
            );
        }

        /// <summary>
        /// Получить отфильтрованный список групп пользователей.
        /// </summary>
        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(ApiPagedFilterResult<ApiGroupDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FilterBy([FromQuery] ApiGroupFilterDtoIn filter)
        {
            if (filter.Count.HasValue && (filter.Count < 1 || filter.Count > 100))
            {
                return BadRequest(ConstantMessages.CountItemPerPageMoreThan100);
            }

            if (filter.Page.HasValue && filter.Page < 1)
            {
                return BadRequest(ConstantMessages.InvalidPageNumber);
            }

            var filterDtoIn = ApiGroupFilterDtoInConverter.ToRepository(filter);

            var filteredGroups = await _siteRepository.GetGroupsByFilterAsync(filterDtoIn);

            return Ok(
                PagedFilterResultConverter.ToApi(filteredGroups)
            );
        }

        /// <summary>
        /// Изменить данные группы пользователей по ID.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiGroupDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, ApiUpdateGroupDtoIn apiUpdateGroupDtoIn)
        {
            var existedGroup = await _siteRepository.GetGroupAsync(id);

            if (existedGroup == null)
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.GroupNotFoundById,
                        id
                    )
                );
            }

            apiUpdateGroupDtoIn = apiUpdateGroupDtoIn with { Name = apiUpdateGroupDtoIn.Name?.Trim() };

            if (apiUpdateGroupDtoIn.Name == null || apiUpdateGroupDtoIn.Name.Length < 3 || apiUpdateGroupDtoIn.Name.Length > 32)
            {
                return BadRequest(ConstantMessages.GroupInvalidNameLength);
            }
            if (!Regex.IsMatch(apiUpdateGroupDtoIn.Name, @"^[0-9a-zA-Zа-яА-Я!@#№$%^&?*()\-_=\[\]{}~`\s]{3,32}$"))
            {
                return BadRequest(ConstantMessages.GroupInvalidName);
            }
            if (apiUpdateGroupDtoIn.Color == null || !Regex.IsMatch(apiUpdateGroupDtoIn.Color, @"^[0-9a-fA-F]{6}$"))
            {
                return BadRequest(ConstantMessages.GroupInvalidColor);
            }
            if (apiUpdateGroupDtoIn.MaxBan < 0 || apiUpdateGroupDtoIn.MaxBan > int.MaxValue)
            {
                return BadRequest(
                    string.Format(
                        ConstantMessages.GroupInvalidMaxBan,
                        0,
                        int.MaxValue
                    )
                );
            }
            if (apiUpdateGroupDtoIn.BanGroupIds == null)
            {
                apiUpdateGroupDtoIn = apiUpdateGroupDtoIn with { BanGroupIds = new int[0] };
            }
            foreach (var banGroupId in apiUpdateGroupDtoIn.BanGroupIds)
            {
                var existedGroupWithBanGroupId = await _siteRepository.GetGroupAsync(banGroupId);

                if (existedGroupWithBanGroupId == null)
                {
                    return BadRequest(
                        string.Format(
                            ConstantMessages.GroupNotFoundWithBanGroupId,
                            existedGroupWithBanGroupId
                        )
                    );
                }
            }

            var groupDtoOut = ApiUpdateGroupDtoInConverter.ToDtoOut(
                source: apiUpdateGroupDtoIn,
                id: id
            );

            var updatedGroupDtoOut = await _siteRepository.UpdateGroupAsync(groupDtoOut);

            return Ok(
                GroupDtoOutConverter.ToApi(updatedGroupDtoOut)
            );
        }

        /// <summary>
        /// Удалить группу пользователей по ID.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var existedGroup = await _siteRepository.GetGroupAsync(id);

            if (existedGroup == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.GroupNotFoundById, id)
                );
            }

            await _siteRepository.DeleteGroupAsync(id);

            return NoContent();
        }
    }
}
