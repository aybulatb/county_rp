using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using CountyRP.WebAPI.Extensions;
using CountyRP.WebAPI.Models;
using CountyRP.WebAPI.Models.ViewModels.VehicleViewModels;

namespace CountyRP.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        private PlayerContext _playerContext;
        private PropertyContext _propertyContext;

        public VehicleController(PlayerContext playerContext, PropertyContext propertyContext)
        {
            _playerContext = playerContext;
            _propertyContext = propertyContext;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Vehicle), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Create(Vehicle createVehicle)
        {
            var result = CheckParams(createVehicle);
            if (result != null)
                return result;

            Entities.Vehicle vehicle = new Entities.Vehicle().Format(createVehicle);

            _propertyContext.Vehicles.Add(vehicle);
            _propertyContext.SaveChanges();

            createVehicle.Format(vehicle);

            return Created("", createVehicle);
        }

        [HttpGet("GetById/{id}")]
        [ProducesResponseType(typeof(Vehicle), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            Entities.Vehicle vehicle = _propertyContext.Vehicles.FirstOrDefault(v => v.Id == id);

            if (vehicle == null)
                return NotFound($"Транспортное средство с ID {id} не найдено");

            return Ok(new Vehicle().Format(vehicle));
        }

        [HttpGet("GetByPersonId/{personId}")]
        [ProducesResponseType(typeof(Vehicle), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetByPersonId(int personId)
        {
            Entities.Vehicle vehicle = _propertyContext.Vehicles.FirstOrDefault(v => v.OwnerId == personId);

            if (vehicle == null)
                return NotFound($"Транспортное средство с владельцем с ID {personId} не найдено");

            return Ok(new Vehicle().Format(vehicle));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Vehicle), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Edit(int id, Vehicle vehicle)
        {
            if (id != vehicle.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID {vehicle.Id} транспортного средства");

            Entities.Vehicle existingVehicle = _propertyContext.Vehicles
                .FirstOrDefault(v => v.Id == vehicle.Id);
            if (existingVehicle == null)
                return NotFound($"Транспортное средство с ID {vehicle.Id} не найдено");

            var result = CheckParams(vehicle);
            if (result != null)
                return result;

            existingVehicle.Format(vehicle);

            _propertyContext.Vehicles.Update(existingVehicle);
            _propertyContext.SaveChanges();

            return Ok(vehicle);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            Entities.Vehicle vehicle = _propertyContext.Vehicles
                .FirstOrDefault(v => v.Id == id);

            if (vehicle == null)
                return NotFound($"Транспортное средство с ID {id} не найдено");

            _propertyContext.Vehicles.Remove(vehicle);
            _propertyContext.SaveChanges();

            return Ok();
        }


        private IActionResult CheckParams(Vehicle vehicle)
        {
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

            return null;
        }
    }
}
