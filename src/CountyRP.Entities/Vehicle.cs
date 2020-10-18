using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace CountyRP.DAO
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int Model { get; set; }
        [NotMapped]
        public float[] Position 
        {
            get { return JsonConvert.DeserializeObject<float[]>(_Position); }
            set { _Position = JsonConvert.SerializeObject(value); } 
        }
        public float Rotation { get; set; }
        public uint Dimension { get; set; }
        public int Color1 { get; set; }
        public int Color2 { get; set; }
        public double Fuel { get; set; }
        public int OwnerId { get; set; }
        public string FactionId { get; set; }
        public bool Lock { get; set; }
        public string LicensePlate { get; set; }

        [Column("Position")]
        public string _Position { get; set; }
    }
}
