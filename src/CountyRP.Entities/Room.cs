using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace CountyRP.Entities
{
    public class Room
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
        public int TypeMarker { get; set; }
        [NotMapped]
        public int[] ColorMarker
        {
            get { return JsonConvert.DeserializeObject<int[]>(_ColorMarker); }
            set { _ColorMarker = JsonConvert.SerializeObject(value); }
        }
        public int TypeBlip { get; set; }
        public byte ColorBlip { get; set; }
        public int GroupId { get; set; }
        public bool Lock { get; set; }
        public int Price { get; set; }
        public DateTime LastPayment { get; set; }
        [NotMapped]
        public float[] SafePosition
        {
            get { return JsonConvert.DeserializeObject<float[]>(_SafePosition); }
            set { _SafePosition = JsonConvert.SerializeObject(value); }
        }
        public uint SafeDimension { get; set; }

        [Column("EntrancePosition")]
        public string _EntrancePosition { get; set; }
        [Column("ExitPosition")]
        public string _ExitPosition { get; set; }
        [Column("ColorMarker")]
        public string _ColorMarker { get; set; }
        [Column("SafePosition")]
        public string _SafePosition { get; set; }
    }
}
