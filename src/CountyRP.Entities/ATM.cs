using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace CountyRP.DAO
{
    public class ATM
    {
        public int Id { get; set; }
        [NotMapped]
        public float[] Position
        {
            get => JsonConvert.DeserializeObject<float[]>(_Position);
            set => _Position = JsonConvert.SerializeObject(value);
        }
        public uint Dimension { get; set; }
        public int BusinessId { get; set; }

        [Column("Position")]
        public string _Position { get; set; }
    }
}
