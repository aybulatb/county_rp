using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using CountyRP.Models;
using CountyRP.WebAPI.DbContexts;

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
            var result = await CheckParamsAsync(vehicle);
            if (result != null)
                return result;

            var vehicleDAO = MapToDAO(vehicle);

            await _propertyContext.Vehicles.AddAsync(vehicleDAO);
            await _propertyContext.SaveChangesAsync();

            vehicle = MapToModel(vehicleDAO);

            return Created("", vehicle);
        }

        [HttpGet("GetById/{id}")]
        [ProducesResponseType(typeof(Vehicle), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var vehicleDAO = await _propertyContext.Vehicles
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.Id == id);

            if (vehicleDAO == null)
                return NotFound($"Транспортное средство с ID {id} не найдено");

            return Ok(
                MapToModel(vehicleDAO)
            );
        }

        [HttpGet]
        [ProducesResponseType(typeof(Vehicle[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var vehiclesDAO = await _propertyContext.Vehicles
                .AsNoTracking()
                .OrderBy(v => v.Id)
                .ToArrayAsync();

            return Ok(
                vehiclesDAO
                    .Select(v => MapToModel(v))
            );
        }

        [HttpGet("GetByPersonId/{personId}")]
        [ProducesResponseType(typeof(Vehicle), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByPersonId(int personId)
        {
            var vehicleDAO = await _propertyContext.Vehicles
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.OwnerId == personId);

            if (vehicleDAO == null)
                return NotFound($"Транспортное средство с владельцем с ID {personId} не найдено");

            return Ok(
                MapToModel(vehicleDAO)
            );
        }

        [HttpGet("GetByLicensePlate/{licensePlate}")]
        [ProducesResponseType(typeof(Vehicle), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByLicensePlate(string licensePlate)
        {
            var vehicleDAO = await _propertyContext.Vehicles
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.LicensePlate == licensePlate);

            if (vehicleDAO == null)
                return NotFound($"Транспортное средство с номером {licensePlate} не найдено");

            return Ok(
                MapToModel(vehicleDAO)
            );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Vehicle), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, [FromBody] Vehicle vehicle)
        {
            if (id != vehicle.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID {vehicle.Id} транспортного средства");

            var isVehicleExisted = await _propertyContext.Vehicles
                .AsNoTracking()
                .AnyAsync(v => v.Id == vehicle.Id);
            if (!isVehicleExisted)
                return NotFound($"Транспортное средство с ID {vehicle.Id} не найдено");

            var result = await CheckParamsAsync(vehicle);
            if (result != null)
                return result;

            var vehicleDAO = MapToDAO(vehicle);

            _propertyContext.Vehicles.Update(vehicleDAO);
            await _propertyContext.SaveChangesAsync();

            return Ok(vehicle);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicleDAO = await _propertyContext.Vehicles
                .FirstOrDefaultAsync(v => v.Id == id);

            if (vehicleDAO == null)
                return NotFound($"Транспортное средство с ID {id} не найдено");

            _propertyContext.Vehicles.Remove(vehicleDAO);
            await _propertyContext.SaveChangesAsync();

            return Ok();
        }


        private async Task<IActionResult> CheckParamsAsync(Vehicle vehicle)
        {
            if (vehicle.Position == null || vehicle.Position.Length != 3)
                return BadRequest("Количество координат позиции должно быть равно 3");

            if (vehicle.LicensePlate == null ||
                !System.Text.RegularExpressions.Regex.IsMatch(vehicle.LicensePlate, @"^\d[A-Z]{3}\d\d\d$"))
                return BadRequest("Номер транспортного средства должен соответствовать формату: ЦБББЦЦЦ");

            var result = await CheckOwnerAsync(vehicle);
            if (result != null)
                return result;

            return null;
        }

        private async Task<IActionResult> CheckOwnerAsync(Vehicle vehicle)
        {
            var isPersonExisted = await _playerContext.Persons
                .AnyAsync(p => p.Id == vehicle.OwnerId);

            if (vehicle.OwnerId != 0 && !isPersonExisted)
                return BadRequest($"Персонаж с ID {vehicle.OwnerId} не найден");

            var isFactionExisted = await _factionContext.Factions
                .AnyAsync(f => f.Id == vehicle.FactionId);

            if (vehicle.FactionId == null || vehicle.FactionId != string.Empty && !isFactionExisted)
                return BadRequest($"Фракция с ID {vehicle.FactionId} не найдена");

            return null;
        }

        private DAO.Vehicle MapToDAO(Vehicle vehicle)
        {
            return new DAO.Vehicle
            {
                Id = vehicle.Id,
                Model = vehicle.Model,
                Position = vehicle.Position
                    ?.Select(p => p)
                    .ToArray(),
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
                Position = vehicle.Position
                    ?.Select(p => p)
                    .ToArray(),
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
