using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace CountyRP.Entities
{
    public class LockerRoom
    {
        public int Id { get; set; }
        [NotMapped]
        public float[] Position
        {
            get { return JsonConvert.DeserializeObject<float[]>(_Position); }
            set { _Position = JsonConvert.SerializeObject(value); }
        }
        public uint Dimension { get; set; }
        public int TypeMarker { get; set; }
        [NotMapped]
        public int[] ColorMarker
        {
            get { return JsonConvert.DeserializeObject<int[]>(_ColorMarker); }
            set { _ColorMarker = JsonConvert.SerializeObject(value); }
        }
        public string FactionId { get; set; }

        [Column("Position")]
        public string _Position { get; set; }
        [Column("ColorMarker")]
        public string _ColorMarker { get; set; }
    }
}
