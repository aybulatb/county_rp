using Newtonsoft.Json;

namespace CountyRP.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.All)]
        public Slot[] Slots { get; set; }
    }

    public class Slot
    {
        public int ItemId { get; set; }
    }
}
