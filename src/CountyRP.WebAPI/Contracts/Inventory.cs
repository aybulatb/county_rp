using Newtonsoft.Json;
using NJsonSchema.Converters;
using System.Runtime.Serialization;

namespace CountyRP.WebAPI.Contracts
{
    public class Inventory
    {
        public int Id { get; set; }
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.All)]
        public Slot[] Slots { get; set; }
    }

    [JsonConverter(typeof(JsonInheritanceConverter))]
    [KnownType(typeof(SimpleSlot))]
    public class Slot
    {
        public int ItemId { get; set; }
    }

    public class SimpleSlot : Slot
    {
        public int Amount { get; set; }
    }
}
