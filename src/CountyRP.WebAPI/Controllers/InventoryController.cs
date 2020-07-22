using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using CountyRP.Models;
using CountyRP.WebAPI.Customizations;
using CountyRP.WebAPI.Models;

namespace CountyRP.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private InventoryContext _inventoryContext;

        public InventoryController(InventoryContext inventoryContext)
        {
            _inventoryContext = inventoryContext;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Inventory), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var inventory = _inventoryContext.Inventories.AsNoTracking().FirstOrDefault(i => i.Id == id);

            if (inventory == null)
                return NotFound($"Инвентарь с ID {id} не найден");

            return Ok(MapToModel(inventory));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Inventory), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody, ModelBinder(typeof(JsonPolyModelBinder))] Inventory inventory)
        {
            var error = CheckParams(inventory);
            if (error != null)
                return error;

            var inventoryEntity = MapToEntity(inventory);
            inventoryEntity.Id = 0;

            _inventoryContext.Inventories.Add(inventoryEntity);
            _inventoryContext.SaveChanges();

            return Created("", MapToModel(inventoryEntity));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Inventory), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Edit(int id, [FromBody, ModelBinder(typeof(JsonPolyModelBinder))] Inventory inventory)
        {
            if (inventory.Id != id)
                return BadRequest($"Указанный ID {id} не соответствует ID {inventory.Id} инвентаря");

            var inventoryEntity = _inventoryContext.Inventories.FirstOrDefault(i => i.Id == id);

            if (inventoryEntity == null)
                return NotFound($"Инвентарь с ID {id} не найден");

            var error = CheckParams(inventory);
            if (error != null)
                return error;


            inventoryEntity.Id = inventory.Id;
            inventoryEntity.Slots = inventory.Slots.Select(s =>
            {
                return new Entities.Slot { ItemId = s.ItemId };
            }).ToArray();

            _inventoryContext.SaveChanges();

            return Ok(inventory);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var inventory = _inventoryContext.Inventories.FirstOrDefault(sb => sb.Id == id);

            if (inventory == null)
                return NotFound($"Инвентарь с ID {id} не найден");

            _inventoryContext.Inventories.Remove(inventory);
            _inventoryContext.SaveChanges();

            return Ok();
        }

        private Entities.Inventory MapToEntity(Inventory i)
        {
            return new Entities.Inventory
            {
                Id = i.Id,
                Slots = i.Slots.Select(s =>
                {
                    return new Entities.Slot { ItemId = s.ItemId };
                }).ToArray()
            };
        }

        private Inventory MapToModel(Entities.Inventory i)
        {
            return new Inventory
            {
                Id = i.Id,
                Slots = i.Slots.Select(s =>
                {
                    return new Slot { ItemId = s.ItemId };
                }).ToArray()
            };
        }

        private IActionResult CheckParams(Inventory inventory)
        {
            return null;
        }
    }
}
