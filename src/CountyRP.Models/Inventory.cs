using System;

namespace CountyRP.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public Slot[] Slots { get; set; }
    }

    public enum InventorySlotType
    {
        Base = 0,
        Backpack = 1
    }

    public class Slot : ICloneable
    {
        public int ItemId { get; set; }
        public int Amount { get; set; }
        public InventorySlotType Type { get; set; }

        public virtual object Clone()
        {
            return new Slot
            {
                ItemId = ItemId,
                Amount = Amount,
                Type = Type
            };
        }

        public virtual void SetSlot(Slot slot)
        {
            ItemId = slot.ItemId;
            Amount = slot.Amount;
        }
    }

    public class BackpackSlot : Slot
    {
        public int Id { get; set; }

        public override object Clone()
        {
            return new BackpackSlot
            {
                ItemId = ItemId,
                Amount = Amount,
                Type = Type,
                Id = Id
            };
        }

        public override void SetSlot(Slot slot)
        {
            base.SetSlot(slot);

            var backpackSlot = slot as BackpackSlot;
            Id = backpackSlot.Id;
        }
    }
}
