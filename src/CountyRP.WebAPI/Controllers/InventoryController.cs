using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using CountyRP.WebAPI.DbContexts;

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
        public async Task<IActionResult> GetById(int id)
        {
            var inventoryDAO = await _inventoryContext.Inventories
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == id);

            if (inventoryDAO == null)
                return NotFound($"Инвентарь с ID {id} не найден");

            return Ok(
                MapToContract(inventoryDAO)
            );
        }

        [HttpPost]
        [ProducesResponseType(typeof(Contracts.Inventory), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Contracts.Inventory inventory)
        {
            var error = CheckParams(inventory);
            if (error != null)
                return error;

            var inventoryDAO = MapToDAO(inventory);
            inventoryDAO.Id = 0;

            await _inventoryContext.Inventories.AddAsync(inventoryDAO);
            await _inventoryContext.SaveChangesAsync();

            return Created("", MapToContract(inventoryDAO));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Contracts.Inventory), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, [FromBody] Contracts.Inventory inventory)
        {
            if (inventory.Id != id)
                return BadRequest($"Указанный ID {id} не соответствует ID {inventory.Id} инвентаря");

            var inventoryDAO = await _inventoryContext.Inventories
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == id);

            if (inventoryDAO == null)
                return NotFound($"Инвентарь с ID {id} не найден");

            var error = CheckParams(inventory);
            if (error != null)
                return error;

            inventoryDAO.Slots = inventory.Slots
                .Select(s => MapSlotToDAO(s))
                .ToArray();

            _inventoryContext.Inventories.Update(inventoryDAO);
            await _inventoryContext.SaveChangesAsync();

            return Ok(inventory);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var inventoryDAO = await _inventoryContext.Inventories
                .FirstOrDefaultAsync(i => i.Id == id);

            if (inventoryDAO == null)
                return NotFound($"Инвентарь с ID {id} не найден");

            _inventoryContext.Inventories.Remove(inventoryDAO);
            await _inventoryContext.SaveChangesAsync();

            return Ok();
        }

        private DAO.Inventory MapToDAO(Contracts.Inventory inv)
        {
            return new DAO.Inventory
            {
                Id = inv.Id,
                Slots = inv.Slots
                    .Select(s => MapSlotToDAO(s))
                    .ToArray()
            };
        }

        private Contracts.Inventory MapToContract(DAO.Inventory i)
        {
            return new Contracts.Inventory
            {
                Id = i.Id,
                Slots = i.Slots
                    .Select(s => MapSlotToContract(s))
                    .ToArray()
            };
        }

        private IActionResult CheckParams(Contracts.Inventory inventory)
        {
            return null;
        }

        private Contracts.Slot MapSlotToContract(DAO.Slot slot)
        {
            switch (slot.Type)
            {
                case DAO.InventorySlotType.Base:
                    {
                        return new Contracts.Slot 
                        { 
                            ItemId = slot.ItemId, 
                            Amount = slot.Amount, 
                            Type = (Contracts.InventorySlotType)slot.Type 
                        };
                    }
                case DAO.InventorySlotType.Backpack:
                    {
                        var cs = slot as DAO.BackpackSlot;
                        return new Contracts.BackpackSlot 
                        { 
                            ItemId = cs.ItemId, 
                            Amount = cs.Amount, 
                            Type = (Contracts.InventorySlotType)cs.Type, 
                            Id = cs.Id 
                        };
                    }
            }

            return null;
        }

        private DAO.Slot MapSlotToDAO(Contracts.Slot slot)
        {
            switch (slot.Type)
            {
                case Contracts.InventorySlotType.Base:
                    {
                        return new DAO.Slot 
                        { 
                            ItemId = slot.ItemId,
                            Amount = slot.Amount, 
                            Type = (DAO.InventorySlotType)slot.Type
                        };
                    }
                case Contracts.InventorySlotType.Backpack:
                    {
                        var cs = slot as Contracts.BackpackSlot;
                        return new DAO.BackpackSlot 
                        { 
                            ItemId = cs.ItemId, 
                            Amount = cs.Amount, 
                            Type = (DAO.InventorySlotType)cs.Type, 
                            Id = cs.Id 
                        };
                    }
            }

            return null;
        }
    }
}
