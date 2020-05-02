namespace CountyRP.Models
{
    public class Business
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float[] EntrancePosition { get; set; }
        public uint EntranceDimension { get; set; }
        public float[] ExitPosition { get; set; }
        public uint ExitDimension { get; set; }
        public int OwnerId { get; set; }
        public bool Lock { get; set; }
        public BusinessType Type { get; set; }
        public int Price { get; set; }
    }

    public enum BusinessType
    {
        None = 0
    }
}
