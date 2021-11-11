namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiVehicleDtoOut
    {
        public int Id { get; init; }

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

        public ApiVehicleDtoOut(
            int id,
            int model,
            float[] position,
            float rotation,
            uint dimension,
            int color1,
            int color2,
            double fuel,
            int? ownerId,
            string factionId,
            bool lockDoors,
            string licensePlate
        )
        {
            Id = id;
            Model = model;
            Position = position;
            Rotation = rotation;
            Dimension = dimension;
            Color1 = color1;
            Color2 = color2;
            Fuel = fuel;
            OwnerId = ownerId;
            FactionId = factionId;
            LockDoors = lockDoors;
            LicensePlate = licensePlate;
        }
    }
}
