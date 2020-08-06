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
        Simple
    }

    public class Slot
    {
        public int ItemId { get; set; }
        public InventorySlotType Type { get; set; }
    }

    public class SimpleSlot : Slot
    {
        public int Amount { get; set; }
    }
}
