using System;

namespace CountyRP.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float[] EntrancePosition { get; set; }
        public uint EntranceDimension { get; set; }
        public float[] ExitPosition { get; set; }
        public uint ExitDimension { get; set; }
        public int TypeMarker { get; set; }
        public int[] ColorMarker { get; set; }
        public int TypeBlip { get; set; }
        public byte ColorBlip { get; set; }
        public int GroupId { get; set; }
        public bool Lock { get; set; }
        public int Price { get; set; }
        public DateTime LastPayment { get; set; }
        public float[] SafePosition { get; set; }
        public uint SafeDimension { get; set; }
    }
}
