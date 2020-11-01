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
    public class BlackMarketController : ControllerBase
    {
        private BlackMarketContext _blackMarketContext;

        public BlackMarketController(BlackMarketContext blackMarketContext)
        {
            _blackMarketContext = blackMarketContext;
        }

        [HttpGet]
        [ProducesResponseType(typeof(LogUnit), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var blackMarketItemsDAO = _blackMarketContext.BlackMarket.AsNoTracking().ToArray();

            return Ok(blackMarketItemsDAO.Select(bmi => MapToModel(bmi)));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(BlackMarketItem), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, [FromBody] BlackMarketItem blackMarketItem)
        {
            if (blackMarketItem.Id != id)
                return BadRequest($"Указанный ID {id} не соответствует ID {blackMarketItem.Id} предмета Чёрного рынка");

            var blackMarketItemDAO = _blackMarketContext.BlackMarket.AsNoTracking().SingleOrDefault(bmi => bmi.Id == id);

            if (blackMarketItemDAO == null)
                return NotFound($"Предмет Чёрного рынка с ID {id} не найден");

            blackMarketItemDAO = MapToDAO(blackMarketItem);

            _blackMarketContext.BlackMarket.Update(blackMarketItemDAO);
            await _blackMarketContext.SaveChangesAsync();

            return Ok(MapToModel(blackMarketItemDAO));
        }

        private DAO.BlackMarketItem MapToDAO(BlackMarketItem blackMarketItem)
        {
            return new DAO.BlackMarketItem
            {
                Id = blackMarketItem.Id,
                Amount = blackMarketItem.Amount
            };
        }

        private BlackMarketItem MapToModel(DAO.BlackMarketItem blackMarketItem)
        {
            return new BlackMarketItem
            {
                Id = blackMarketItem.Id,
                Amount = blackMarketItem.Amount
            };
        }
    }
}
