using CountyRP.Services.Logs.API.Converters;
using CountyRP.Services.Logs.API.Models.Api;
using CountyRP.Services.Logs.Infrastructure.Models;
using CountyRP.Services.Logs.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CountyRP.Services.Logs.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogUnitController : ControllerBase
    {
        private readonly ILogger<LogUnitController> _logger;
        private ILogsRepository _logsRepository;

        public LogUnitController(
            ILogger<LogUnitController> logger,
            ILogsRepository logsRepository
        )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logsRepository = logsRepository ?? throw new ArgumentNullException(nameof(logsRepository));
        }

        /// <summary>
        /// Создать группу пользователей.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiLogUnitDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(ApiLogUnitDtoIn apiLogUnitDtoIn)
        {
            apiLogUnitDtoIn.Login = apiLogUnitDtoIn.Login?.Trim();
            apiLogUnitDtoIn.IP = apiLogUnitDtoIn.IP?.Trim();
            apiLogUnitDtoIn.Text = apiLogUnitDtoIn.Text?.Trim();

            if (apiLogUnitDtoIn.Login?.Length > 32)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.LogUnitInvalidLoginLength,
                        message: ConstantMessages.LogUnitInvalidLoginLength
                    )
                );
            }
            if (!string.IsNullOrEmpty(apiLogUnitDtoIn.IP) && !Regex.IsMatch(apiLogUnitDtoIn.IP, @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$"))
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.InvalidIP,
                        message: ConstantMessages.InvalidIP
                    )
                );
            }
            if (apiLogUnitDtoIn.Text == null || apiLogUnitDtoIn.Text.Length < 1 || apiLogUnitDtoIn.Text.Length > 128)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.LogUnitInvalidTextLength,
                        message: ConstantMessages.LogUnitInvalidTextLength)
                );
            }

            var logUnitDtoIn = ApiLogUnitDtoInConverter.ToRepository(apiLogUnitDtoIn);

            var logUnitDtoOut = await _logsRepository.AddLogUnitAsync(logUnitDtoIn);

            return Ok(
                LogUnitDtoOutConverter.ToApi(logUnitDtoOut)
            );
        }

        /// <summary>
        /// Получить отфильтрованный список логов.
        /// </summary>
        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(ApiPagedFilterResultDtoOut<ApiLogUnitDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FilterBy([FromQuery] ApiLogUnitFilterDtoIn filter)
        {
            if (filter.Count < 1 || filter.Count > 100)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.CountItemPerPageMoreThan100,
                        message: ConstantMessages.CountItemPerPageMoreThan100)
                );
            }

            if (filter.Page < 1)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.InvalidPageNumber,
                        message: ConstantMessages.InvalidPageNumber)
                );
            }

            var filterDtoIn = ApiLogUnitFilterDtoInConverter.ToRepository(filter);

            var filteredLogUnits = await _logsRepository.GetLogUnitsByFilterAsync(filterDtoIn);

            return Ok(
                PagedFilterResultDtoOutConverter.ToApi(filteredLogUnits)
            );
        }

        /// <summary>
        /// Удалить логи по ID.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiLogUnitDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteById(int id)
        {
            var filter = new LogUnitFilterDtoIn(
                count: 1,
                page: 1,
                ids: new[] { id },
                startDateTime: null,
                finishDateTime: null,
                login: null,
                ip: null,
                actionId: null,
                text: null
            );

            var existedLogUnit = await _logsRepository.GetLogUnitsByFilterAsync(filter);

            if (!existedLogUnit.Items.Any())
            {
                return NotFound(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.InvalidPageNumber,
                        message: string.Format(ConstantMessages.LogUnitNotFoundById, id)
                    )
                );
            }

            await _logsRepository.DeleteLogUnitsAsync(filter);

            return Ok();
        }

        /// <summary>
        /// Удалить все логи, которые старше времени dateTime.
        /// </summary>
        [HttpDelete("ByTime/{dateTime}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteByTime(DateTimeOffset dateTime)
        {
            await _logsRepository.DeleteLogUnitsAsync(
                filter: new LogUnitFilterDtoIn(
                    count: null,
                    page: null,
                    ids: null,
                    startDateTime: null,
                    finishDateTime: dateTime,
                    login: null,
                    ip: null,
                    actionId: null,
                    text: null
                )
            );

            return Ok();
        }
    }
}
