using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace CountyRP.DAO
{
    public class Garage
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public int HouseId { get; set; }
        [NotMapped]
        public float[] EntrancePosition 
        {
            get => JsonConvert.DeserializeObject<float[]>(_EntrancePosition);
            set => _EntrancePosition = JsonConvert.SerializeObject(value);
        }
        public uint EntranceDimension { get; set; }
        public uint ExitDimension { get; set; }
        public bool Lock { get; set; }

        [Column("EntrancePosition")]
        public string _EntrancePosition { get; set; }
    }
}
