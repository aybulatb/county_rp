using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace CountyRP.DAO
{
    public class House
    {
        public int Id { get; set; }
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
        public int Price { get; set; }
        [NotMapped]
        public float[] SafePosition
        {
            get => JsonConvert.DeserializeObject<float[]>(_SafePosition);
            set => _SafePosition = JsonConvert.SerializeObject(value);
        }
        public uint SafeDimension { get; set; }

        [Column("EntrancePosition")]
        public string _EntrancePosition { get; set; }
        [Column("ExitPosition")]
        public string _ExitPosition { get; set; }
        [Column("SafePosition")]
        public string _SafePosition { get; set; }
    }
}
