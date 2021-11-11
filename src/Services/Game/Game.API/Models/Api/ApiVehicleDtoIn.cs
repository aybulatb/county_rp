namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiVehicleDtoIn
    {
        public int Model { get; init; }

        public float[] Position { get; init; }

        public float Rotation { get; init; }

        public uint Dimension { get; init; }

        public int Color1 { get; init; }

        public int Color2 { get; init; }

        public double Fuel { get; init; }

        public int? OwnerId { get; init; }

        public string FactionId { get; init; }

        public bool LockDoors { get; init; }

        public string LicensePlate { get; init; }
    }
}
