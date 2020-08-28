using Newtonsoft.Json;
using NJsonSchema.Converters;
using System.Runtime.Serialization;

namespace CountyRP.WebAPI.Contracts
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

    [JsonConverter(typeof(JsonInheritanceConverter))]
    [KnownType(typeof(BackpackSlot))]
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
