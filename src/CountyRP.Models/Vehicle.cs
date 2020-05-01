namespace CountyRP.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int Model { get; set; }
        public float[] Position { get; set; }
        public float Rotation { get; set; }
        public uint Dimension { get; set; }
        public int Color1 { get; set; }
        public int Color2 { get; set; }
        public double Fuel { get; set; }
        public int OwnerId { get; set; }
        public string FactionId { get; set; }
        public bool Lock { get; set; }
        public string LicensePlate { get; set; }
    }
}
