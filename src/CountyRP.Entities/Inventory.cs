using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace CountyRP.Entities
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
