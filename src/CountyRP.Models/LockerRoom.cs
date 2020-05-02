namespace CountyRP.Models
{
    public class LockerRoom
    {
        public int Id { get; set; }
        public float[] Position { get; set; }
        public uint Dimension { get; set; }
        public int TypeMarker { get; set; }
        public int[] ColorMarker { get; set; }
        public string FactionId { get; set; }
    }
}
