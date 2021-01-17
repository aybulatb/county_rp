namespace CountyRP.Models
{
    public class Teleport
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
        public string FactionId { get; set; }
        public int GangId { get; set; }
        public int RoomId { get; set; }
        public int BusinessId { get; set; }
        public bool Lock { get; set; }
    }
}
