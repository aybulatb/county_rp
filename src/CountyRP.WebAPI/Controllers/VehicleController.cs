using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using CountyRP.Entities;
using CountyRP.WebAPI.Models;
using CountyRP.WebAPI.Models.ViewModels.VehicleViewModels;

namespace CountyRP.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private PropertyContext _propertyContext;

        public VehicleController(PropertyContext propertyContext)
        {
            _propertyContext = propertyContext;
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(Vehicle), StatusCodes.Status201Created)]
        public IActionResult Create(CreateVehicle createVehicle)
        {
            Vehicle vehicle = new Vehicle
            {
                PersonId = createVehicle.PersonId
            };

            _propertyContext.Vehicles.Add(vehicle);
            _propertyContext.SaveChanges();

            return Created("", vehicle);
        }

        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(typeof(Vehicle), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            Vehicle vehicle = _propertyContext.Vehicles.FirstOrDefault(v => v.Id == id);

            if (vehicle == null)
                return NotFound();

            return Ok(vehicle);
        }

        [HttpGet]
        [Route("GetByPersonId")]
        [ProducesResponseType(typeof(Vehicle), StatusCodes.Status200OK)]
        public IActionResult GetByPersonId(int personId)
        {
            Vehicle vehicle = _propertyContext.Vehicles.FirstOrDefault(v => v.PersonId == personId);

            if (vehicle == null)
                return NotFound();

            return Ok(vehicle);
        }

        [HttpGet]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
