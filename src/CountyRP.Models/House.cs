namespace CountyRP.Models
{
    public class House
    {
        public int Id { get; set; }
        public float[] EntrancePosition { get; set; }
        public uint EntranceDimension { get; set; }
        public float[] ExitPosition { get; set; }
        public uint ExitDimension { get; set; }
        public int OwnerId { get; set; }
        public bool Lock { get; set; }
        public int Price { get; set; }
        public float[] SafePosition { get; set; }
        public uint SafeDimension { get; set; }
    }
}
