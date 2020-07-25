namespace CountyRP.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public Slot[] Slots { get; set; }
    }

    public class Slot
    {
        public int ItemId { get; set; }
    }

    public class SimpleSlot : Slot
    {
        public int Amount { get; set; }
    }
}
