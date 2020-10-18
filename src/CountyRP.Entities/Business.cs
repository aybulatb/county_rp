using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace CountyRP.DAO
{
    public class Business
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public float[] EntrancePosition
        {
            get { return JsonConvert.DeserializeObject<float[]>(_EntrancePosition); }
            set { _EntrancePosition = JsonConvert.SerializeObject(value); } 
        }
        public uint EntranceDimension { get; set; }
        [NotMapped]
        public float[] ExitPosition
        {
            get { return JsonConvert.DeserializeObject<float[]>(_ExitPosition); }
            set { _ExitPosition = JsonConvert.SerializeObject(value); } 
        }
        public uint ExitDimension { get; set; }
        public int OwnerId { get; set; }
        public bool Lock { get; set; }
        public Models.BusinessType Type { get; set; }
        public int Price { get; set; }

        [Column("EntrancePosition")]
        public string _EntrancePosition { get; set; }
        [Column("ExitPosition")]
        public string _ExitPosition { get; set; }
    }
}
