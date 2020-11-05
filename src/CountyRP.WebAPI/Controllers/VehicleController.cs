using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using CountyRP.Models;
using CountyRP.WebAPI.Models;

namespace CountyRP.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        private PlayerContext _playerContext;
        private PropertyContext _propertyContext;
        private FactionContext _factionContext;

        public VehicleController(PlayerContext playerContext, PropertyContext propertyContext, FactionContext factionContext)
        {
            _playerContext = playerContext;
            _propertyContext = propertyContext;
            _factionContext = factionContext;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Vehicle), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Vehicle vehicle)
        {
            var result = CheckParams(vehicle);
            if (result != null)
                return result;

            var vehicleDAO = MapToDAO(vehicle);

            _propertyContext.Vehicles.Add(vehicleDAO);
            await _propertyContext.SaveChangesAsync();

            vehicle = MapToModel(vehicleDAO);

            return Created("", vehicle);
        }

        [HttpGet("GetById/{id}")]
        [ProducesResponseType(typeof(Vehicle), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var vehicleDAO = _propertyContext.Vehicles.AsNoTracking().FirstOrDefault(v => v.Id == id);

            if (vehicleDAO == null)
                return NotFound($"Транспортное средство с ID {id} не найдено");

            return Ok(MapToModel(vehicleDAO));
        }

        [HttpGet]
        [ProducesResponseType(typeof(Vehicle[]), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var vehiclesDAO = _propertyContext.Vehicles.AsNoTracking().OrderBy(v => v.Id).ToArray();

            return Ok(vehiclesDAO.Select(v => MapToModel(v)));
        }

        [HttpGet("GetByPersonId/{personId}")]
        [ProducesResponseType(typeof(Vehicle), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetByPersonId(int personId)
        {
            var vehicleDAO = _propertyContext.Vehicles.AsNoTracking().FirstOrDefault(v => v.OwnerId == personId);

            if (vehicleDAO == null)
                return NotFound($"Транспортное средство с владельцем с ID {personId} не найдено");

            return Ok(MapToModel(vehicleDAO));
        }

        [HttpGet("GetByLicensePlate/{licensePlate}")]
        [ProducesResponseType(typeof(Vehicle), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetByLicensePlate(string licensePlate)
        {
            var vehicleDAO = _propertyContext.Vehicles.AsNoTracking().FirstOrDefault(v => v.LicensePlate == licensePlate);

            if (vehicleDAO == null)
                return NotFound($"Транспортное средство с номером {licensePlate} не найдено");

            return Ok(MapToModel(vehicleDAO));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Vehicle), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, [FromBody] Vehicle vehicle)
        {
            if (id != vehicle.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID {vehicle.Id} транспортного средства");

            var vehicleDAO = _propertyContext.Vehicles.AsNoTracking().FirstOrDefault(v => v.Id == vehicle.Id);
            if (vehicleDAO == null)
                return NotFound($"Транспортное средство с ID {vehicle.Id} не найдено");

            var result = CheckParams(vehicle);
            if (result != null)
                return result;

            vehicleDAO = MapToDAO(vehicle);

            _propertyContext.Vehicles.Update(vehicleDAO);
            await _propertyContext.SaveChangesAsync();

            return Ok(vehicle);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicleDAO = _propertyContext.Vehicles.FirstOrDefault(v => v.Id == id);

            if (vehicleDAO == null)
                return NotFound($"Транспортное средство с ID {id} не найдено");

            _propertyContext.Vehicles.Remove(vehicleDAO);
            await _propertyContext.SaveChangesAsync();

            return Ok();
        }


        private IActionResult CheckParams(Vehicle vehicle)
        {
            if (vehicle.Position == null || vehicle.Position.Length != 3)
                return BadRequest("Количество координат позиции должно быть равно 3");

            if (vehicle.LicensePlate == null ||
                !System.Text.RegularExpressions.Regex.IsMatch(vehicle.LicensePlate, @"^\d[A-Z]{3}\d\d\d$"))
                return BadRequest("Номер транспортного средства должен соответствовать формату: ЦБББЦЦЦ");

            var result = CheckOwner(vehicle);
            if (result != null)
                return result;

            return null;
        }

        private IActionResult CheckOwner(Vehicle vehicle)
        {
            if (vehicle.OwnerId != 0 &&
                _playerContext.Persons.FirstOrDefault(p => p.Id == vehicle.OwnerId) == null)
                return BadRequest($"Персонаж с ID {vehicle.OwnerId} не найден");

            if (vehicle.FactionId == null || 
                vehicle.FactionId != string.Empty &&
                _factionContext.Factions.FirstOrDefault(f => f.Id == vehicle.FactionId) == null)
                return BadRequest($"Фракция с ID {vehicle.FactionId} не найдена");

            return null;
        }

        private DAO.Vehicle MapToDAO(Vehicle vehicle)
        {
            return new DAO.Vehicle
            {
                Id = vehicle.Id,
                Model = vehicle.Model,
                Position = vehicle.Position?.Select(p => p).ToArray(),
                Rotation = vehicle.Rotation,
                Dimension = vehicle.Dimension,
                Color1 = vehicle.Color1,
                Color2 = vehicle.Color2,
                Fuel = vehicle.Fuel,
                OwnerId = vehicle.OwnerId,
                FactionId = vehicle.FactionId,
                Lock = vehicle.Lock,
                LicensePlate = vehicle.LicensePlate
            };
        }

        private Vehicle MapToModel(DAO.Vehicle vehicle)
        {
            return new Vehicle
            {
                Id = vehicle.Id,
                Model = vehicle.Model,
                Position = vehicle.Position?.Select(p => p).ToArray(),
                Rotation = vehicle.Rotation,
                Dimension = vehicle.Dimension,
                Color1 = vehicle.Color1,
                Color2 = vehicle.Color2,
                Fuel = vehicle.Fuel,
                OwnerId = vehicle.OwnerId,
                FactionId = vehicle.FactionId,
                Lock = vehicle.Lock,
                LicensePlate = vehicle.LicensePlate
            };
        }
    }
}
