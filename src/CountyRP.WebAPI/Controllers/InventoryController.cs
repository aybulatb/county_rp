using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [ProducesResponseType(typeof(Contracts.Inventory), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var inventory = _inventoryContext.Inventories.AsNoTracking().FirstOrDefault(i => i.Id == id);

            if (inventory == null)
                return NotFound($"Инвентарь с ID {id} не найден");

            return Ok(MapToContract(inventory));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Contracts.Inventory), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] Contracts.Inventory inventory)
        {
            var error = CheckParams(inventory);
            if (error != null)
                return error;

            var inventoryEntity = MapToEntity(inventory);
            inventoryEntity.Id = 0;

            _inventoryContext.Inventories.Add(inventoryEntity);
            _inventoryContext.SaveChanges();

            return Created("", MapToContract(inventoryEntity));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Contracts.Inventory), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Edit(int id, [FromBody] Contracts.Inventory inventory)
        {
            if (inventory.Id != id)
                return BadRequest($"Указанный ID {id} не соответствует ID {inventory.Id} инвентаря");

            var inventoryEntity = _inventoryContext.Inventories.FirstOrDefault(i => i.Id == id);

            if (inventoryEntity == null)
                return NotFound($"Инвентарь с ID {id} не найден");

            var error = CheckParams(inventory);
            if (error != null)
                return error;

            inventoryEntity.Slots = inventory.Slots.Select(s => MapSlotToEntity(s)).ToArray();

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

        private Entities.Inventory MapToEntity(Contracts.Inventory inv)
        {
            return new Entities.Inventory
            {
                Id = inv.Id,
                Slots = inv.Slots.Select(s => MapSlotToEntity(s)).ToArray()
            };
        }

        private Contracts.Inventory MapToContract(Entities.Inventory i)
        {
            return new Contracts.Inventory
            {
                Id = i.Id,
                Slots = i.Slots.Select(s => MapSlotToContract(s)).ToArray()
            };
        }

        private IActionResult CheckParams(Contracts.Inventory inventory)
        {
            return null;
        }

        private Contracts.Slot MapSlotToContract(Entities.Slot slot)
        {
            switch (slot.Type)
            {
                case Entities.InventorySlotType.Base:
                    {
                        return new Contracts.Slot { ItemId = slot.ItemId, Type = (Contracts.InventorySlotType)slot.Type };
                    }
                case Entities.InventorySlotType.Simple:
                    {
                        var cs = slot as Entities.SimpleSlot;
                        return new Contracts.SimpleSlot { ItemId = cs.ItemId, Type = (Contracts.InventorySlotType)cs.Type, Amount = cs.Amount };
                    }
            }

            return null;
        }

        private Entities.Slot MapSlotToEntity(Contracts.Slot slot)
        {
            switch (slot.Type)
            {
                case Contracts.InventorySlotType.Base:
                    {
                        return new Entities.Slot { ItemId = slot.ItemId, Type = (Entities.InventorySlotType)slot.Type };
                    }
                case Contracts.InventorySlotType.Simple:
                    {
                        var cs = slot as Contracts.SimpleSlot;
                        return new Entities.SimpleSlot { ItemId = cs.ItemId, Type = (Entities.InventorySlotType)cs.Type, Amount = cs.Amount };
                    }
            }

            return null;
        }
    }
}
