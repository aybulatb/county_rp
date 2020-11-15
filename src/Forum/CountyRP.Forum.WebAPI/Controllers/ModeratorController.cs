using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CountyRP.Forum.WebAPI.Services.Interfaces;
using CountyRP.Forum.Domain.Models;

namespace CountyRP.Forum.WebAPI.Controllers
{
    [ApiController]
    [Route("Forum/api/[controller]")]
    public class ModeratorController : ControllerBase
    {
        private readonly IModeratorService _moderatorService;

        public ModeratorController(IModeratorService moderatorService)
        {
            _moderatorService = moderatorService;
        }

        /// <summary>
        /// Получить список всех модераторов
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(Moderator), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _moderatorService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получить модератора с ID id
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Moderator), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _moderatorService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
