using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CountyRP.Models;
using CountyRP.WebAPI.Extensions;
using CountyRP.WebAPI.Models;

namespace CountyRP.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminLevelController : ControllerBase
    {
        private AdminLevelContext _adminLevelContext;

        public AdminLevelController(AdminLevelContext adminLevelContext)
        {
            _adminLevelContext = adminLevelContext;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AdminLevel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody]AdminLevel adminLevel)
        {
            var result = CheckParams(adminLevel);
            if (result != null)
                return result;

            if (_adminLevelContext.AdminLevels.FirstOrDefault(al => al.Id == adminLevel.Id) != null)
                return BadRequest($"Уровень админки с ID {adminLevel.Id} уже существует");

            Entities.AdminLevel adminLevelEntity = new Entities.AdminLevel().Format(adminLevel);

            _adminLevelContext.AdminLevels.Add(adminLevelEntity);
            _adminLevelContext.SaveChanges();

            return Created("", adminLevel);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AdminLevel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Get(string id)
        {
            Entities.AdminLevel adminLevel = _adminLevelContext.AdminLevels.FirstOrDefault(al => al.Id == id);

            if (adminLevel == null)
                return NotFound($"Уровень админки с ID {id} не найден");

            return Ok(new AdminLevel().Format(adminLevel));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AdminLevel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Edit(string id, [FromBody]AdminLevel adminLevel)
        {
            if (id != adminLevel.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID уровня админки {adminLevel}");

            var result = CheckParams(adminLevel);
            if (result != null)
                return result;

            Entities.AdminLevel adminLevelEntity = _adminLevelContext.AdminLevels.FirstOrDefault(al => al.Id == id);
            if (adminLevelEntity == null)
                return NotFound($"Уровень админки с ID {id} не найден");

            adminLevelEntity.Format(adminLevel);
            _adminLevelContext.SaveChanges();

            return Ok(adminLevel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Delete(string id)
        {
            Entities.AdminLevel adminLevel = _adminLevelContext.AdminLevels.FirstOrDefault(al => al.Id == id);

            if (adminLevel == null)
                return NotFound($"Уровень админки с ID {id} не найден");

            _adminLevelContext.AdminLevels.Remove(adminLevel);

            return Ok();
        }

        private IActionResult CheckParams(AdminLevel adminLevel)
        {
            TrimParams(adminLevel);

            if (adminLevel.Id == null || !System.Text.RegularExpressions.Regex.IsMatch(adminLevel.Id, "^[a-zA-Z0-9]{3,16}$"))
                return BadRequest("ID должен состоять из латинских букв и цифр от 3 до 16 символов");

            if (adminLevel.Name == null || adminLevel.Name.Length < 3 || adminLevel.Name.Length > 32)
                return BadRequest("Название должно быть от 3 до 32 символов");

            return null;
        }

        private void TrimParams(AdminLevel adminLevel)
        {
            adminLevel.Id = adminLevel.Id?.Trim();
            adminLevel.Name = adminLevel.Name?.Trim();
        }
    }
}
