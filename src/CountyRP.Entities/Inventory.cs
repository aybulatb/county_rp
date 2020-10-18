using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace CountyRP.DAO
{
    public class Inventory
    {
        public int Id { get; set; }
        [NotMapped]
        public Slot[] Slots 
        {
            get { return JsonConvert.DeserializeObject<Slot[]>(_Slots, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto }); }
            set { _Slots = JsonConvert.SerializeObject(value, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto }); }
        }

        [Column("Slots")]
        public string _Slots { get; set; }
    }

    public enum InventorySlotType
    {
        Base = 0,
        Backpack = 1
    }

    public class Slot
    {
        public int ItemId { get; set; }
        public int Amount { get; set; }
        public InventorySlotType Type { get; set; }
    }

    public class BackpackSlot : Slot
    {
        public int Id { get; set; }
    }
}
