using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using CountyRP.Models;
using CountyRP.WebAPI.Models;

namespace CountyRP.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GarageController : ControllerBase
    {
        private PropertyContext _propertyContext;

        public GarageController(PropertyContext propertyContext)
        {
            _propertyContext = propertyContext;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Garage), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Garage garage)
        {
            var result = CheckParams(garage);
            if (result != null)
                return result;

            garage.Id = 0;

            var garageDAO = MapToDAO(garage);

            _propertyContext.Garages.Add(garageDAO);
            await _propertyContext.SaveChangesAsync();

            garage.Id = garageDAO.Id;

            return Created("", garage);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Garage[]), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var garagesDAO = _propertyContext.Garages.AsNoTracking().ToArray();

            return Ok(garagesDAO.Select(h => MapToModel(h)));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Garage), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var garageDAO = _propertyContext.Garages.AsNoTracking().FirstOrDefault(g => g.Id == id);
            if (garageDAO == null)
                return NotFound($"Гараж с ID {id} не найден");

            return Ok(MapToModel(garageDAO));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Garage), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, [FromBody] Garage garage)
        {
            if (id != garage.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID дома {garage.Id}");

            var result = CheckParams(garage);
            if (result != null)
                return result;

            var garageDAO = _propertyContext.Garages.AsNoTracking().FirstOrDefault(g => g.Id == id);
            if (garageDAO == null)
                return NotFound($"Гараж с ID {id} не найден");

            garageDAO = MapToDAO(garage);

            _propertyContext.Garages.Update(garageDAO);
            await _propertyContext.SaveChangesAsync();

            return Ok(garage);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var garageDAO = _propertyContext.Garages.FirstOrDefault(g => g.Id == id);
            if (garageDAO == null)
                return NotFound($"Гараж с ID {id} не найден");

            _propertyContext.Garages.Remove(garageDAO);
            await _propertyContext.SaveChangesAsync();

            return Ok();
        }

        private IActionResult CheckParams(Garage garage)
        {
            if (garage.EntrancePosition?.Length != 3)
                return BadRequest("Количество координат входа должно быть равно 3");

            var result = CheckOwner(garage);
            if (result != null)
                return result;

            return null;
        }

        private IActionResult CheckOwner(Garage garage)
        {
            if (garage.HouseId != 0 && 
                _propertyContext.Garages.FirstOrDefault(h => h.Id == garage.HouseId) == null)
                return BadRequest($"Гараж с ID {garage.HouseId} не найден");

            return null;
        }

        private DAO.Garage MapToDAO(Garage garage)
        {
            return new DAO.Garage
            {
                Id = garage.Id,
                Type = garage.Type,
                HouseId = garage.HouseId,
                EntrancePosition = garage.EntrancePosition?.ToArray(),
                EntranceDimension = garage.EntranceDimension,
                ExitDimension = garage.ExitDimension,
                Lock = garage.Lock
            };
        }

        private Garage MapToModel(DAO.Garage garage)
        {
            return new Garage
            {
                Id = garage.Id,
                Type = garage.Type,
                HouseId = garage.HouseId,
                EntrancePosition = garage.EntrancePosition?.ToArray(),
                EntranceDimension = garage.EntranceDimension,
                ExitDimension = garage.ExitDimension,
                Lock = garage.Lock
            };
        }
    }
}
