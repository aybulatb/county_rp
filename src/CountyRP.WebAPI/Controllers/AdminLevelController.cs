using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CountyRP.Models;
using CountyRP.WebAPI.Models;
using CountyRP.WebAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Create([FromBody] AdminLevel adminLevel)
        {
            var result = CheckParams(adminLevel);
            if (result != null)
                return result;

            if (_adminLevelContext.AdminLevels.FirstOrDefault(al => al.Id == adminLevel.Id) != null)
                return BadRequest($"Уровень админки с ID {adminLevel.Id} уже существует");

            var adminLevelDAO = MapToDAO(adminLevel);

            _adminLevelContext.AdminLevels.Add(adminLevelDAO);
            await _adminLevelContext.SaveChangesAsync();

            return Created("", adminLevel);
        }

        [HttpGet]
        [ProducesResponseType(typeof(AdminLevel[]), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var adminLevelsDAO = _adminLevelContext.AdminLevels.AsNoTracking().ToArray();

            return Ok(adminLevelsDAO.Select(al => MapToModel(al)));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AdminLevel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetById(string id)
        {
            var adminLevelDAO = _adminLevelContext.AdminLevels.AsNoTracking().FirstOrDefault(al => al.Id == id);

            if (adminLevelDAO == null)
                return NotFound($"Уровень админки с ID {id} не найден");

            return Ok(MapToModel(adminLevelDAO));
        }

        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(FilteredModels<AdminLevel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult FilterBy(int page, int count, string id, string name)
        {
            if (page < 1)
                return BadRequest("Номер страницы админских уровней не может быть меньше 1");

            if (count < 1 || count > 50)
                return BadRequest("Количество админских уровней на одной странице должно быть от 1 до 50");

            IQueryable<DAO.AdminLevel> query = _adminLevelContext.AdminLevels;
            if (!string.IsNullOrWhiteSpace(id))
                query = query.Where(al => al.Id.Contains(id));
            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(al => al.Name.Contains(name));

            int allAmount = query.Count();
            int maxPage = (allAmount % count == 0) ? allAmount / count : allAmount / count + 1;
            if (page > maxPage && maxPage > 0)
                page = maxPage;

            var choosenAdminLevels = query
                    .Skip((page - 1) * count)
                    .Take(count)
                    .ToList();

            return Ok(new FilteredModels<AdminLevel>
            {
                Items = choosenAdminLevels.Select(al => MapToModel(al)).ToList(),
                AllAmount = allAmount,
                Page = page,
                MaxPage = maxPage
            });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AdminLevel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(string id, [FromBody] AdminLevel adminLevel)
        {
            if (id != adminLevel.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID уровня админки {adminLevel}");

            var result = CheckParams(adminLevel);
            if (result != null)
                return result;

            var adminLevelDAO = _adminLevelContext.AdminLevels.AsNoTracking().FirstOrDefault(al => al.Id == id);
            if (adminLevelDAO == null)
                return NotFound($"Уровень админки с ID {id} не найден");

            adminLevelDAO = MapToDAO(adminLevel);
            _adminLevelContext.AdminLevels.Update(adminLevelDAO);
            await _adminLevelContext.SaveChangesAsync();

            return Ok(adminLevel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            var adminLevel = _adminLevelContext.AdminLevels.FirstOrDefault(al => al.Id == id);

            if (adminLevel == null)
                return NotFound($"Уровень админки с ID {id} не найден");

            _adminLevelContext.AdminLevels.Remove(adminLevel);
            await _adminLevelContext.SaveChangesAsync();

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

        private DAO.AdminLevel MapToDAO(AdminLevel adminLevel)
        {
            return new DAO.AdminLevel
            {
                Id = adminLevel.Id,
                Name = adminLevel.Name,
                Ban = adminLevel.Ban,
                CreateVehicle = adminLevel.CreateVehicle,
                EditVehicle = adminLevel.EditVehicle,
                DeleteVehicle = adminLevel.DeleteVehicle,
                CreateFaction = adminLevel.CreateFaction,
                EditFaction = adminLevel.EditFaction,
                DeleteFaction = adminLevel.DeleteFaction,
                CreateHouse = adminLevel.CreateHouse,
                EditHouse = adminLevel.EditHouse,
                DeleteHouse = adminLevel.DeleteHouse,
                CreateBusiness = adminLevel.CreateBusiness,
                EditBusiness = adminLevel.EditBusiness,
                DeleteBusiness = adminLevel.DeleteBusiness,
                CreateTeleport = adminLevel.CreateTeleport,
                EditTeleport = adminLevel.EditTeleport,
                DeleteTeleport = adminLevel.DeleteTeleport,
                CreateGang = adminLevel.CreateGang,
                EditGang = adminLevel.EditGang,
                DeleteGang = adminLevel.DeleteGang,
                CreateLockerRoom = adminLevel.CreateLockerRoom,
                EditLockerRoom = adminLevel.EditLockerRoom,
                DeleteLockerRoom = adminLevel.DeleteLockerRoom,
                CreateATM = adminLevel.CreateATM,
                EditATM = adminLevel.EditATM,
                DeleteATM = adminLevel.DeleteATM,
                CreateRoom = adminLevel.CreateRoom,
                EditRoom = adminLevel.EditRoom,
                DeleteRoom = adminLevel.DeleteRoom
            };
        }

        private AdminLevel MapToModel(DAO.AdminLevel adminLevel)
        {
            return new AdminLevel
            {
                Id = adminLevel.Id,
                Name = adminLevel.Name,
                Ban = adminLevel.Ban,
                CreateVehicle = adminLevel.CreateVehicle,
                EditVehicle = adminLevel.EditVehicle,
                DeleteVehicle = adminLevel.DeleteVehicle,
                CreateFaction = adminLevel.CreateFaction,
                EditFaction = adminLevel.EditFaction,
                DeleteFaction = adminLevel.DeleteFaction,
                CreateHouse = adminLevel.CreateHouse,
                EditHouse = adminLevel.EditHouse,
                DeleteHouse = adminLevel.DeleteHouse,
                CreateBusiness = adminLevel.CreateBusiness,
                EditBusiness = adminLevel.EditBusiness,
                DeleteBusiness = adminLevel.DeleteBusiness,
                CreateTeleport = adminLevel.CreateTeleport,
                EditTeleport = adminLevel.EditTeleport,
                DeleteTeleport = adminLevel.DeleteTeleport,
                CreateGang = adminLevel.CreateGang,
                EditGang = adminLevel.EditGang,
                DeleteGang = adminLevel.DeleteGang,
                CreateLockerRoom = adminLevel.CreateLockerRoom,
                EditLockerRoom = adminLevel.EditLockerRoom,
                DeleteLockerRoom = adminLevel.DeleteLockerRoom,
                CreateATM = adminLevel.CreateATM,
                EditATM = adminLevel.EditATM,
                DeleteATM = adminLevel.DeleteATM,
                CreateRoom = adminLevel.CreateRoom,
                EditRoom = adminLevel.EditRoom,
                DeleteRoom = adminLevel.DeleteRoom
            };
        }
    }
}
