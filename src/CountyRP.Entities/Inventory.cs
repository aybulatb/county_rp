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
            get { return JsonConvert.DeserializeObject<Slot[]>(_Slots); }
            set { _Slots = JsonConvert.SerializeObject(value); }
        }

        [Column("Slots")]
        public string _Slots { get; set; }
    }

    public class Slot
    {
        public int ItemId { get; set; }
    }
}
