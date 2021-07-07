namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class VehicleDtoOut
    {
        public int Id { get; }

        public int Model { get; }

        public float[] Position { get; }

        public float Rotation { get; }

        public uint Dimension { get; }

        public int Color1 { get; }

        public int Color2 { get; }

        public double Fuel { get; }

        public int OwnerId { get; }

        public string FactionId { get; }

        public bool LockDoors { get; }

        public string LicensePlate { get; }

        public VehicleDtoOut(
            int id,
            int model,
            float rotation,
            uint dimension,
            int color1,
            int color2,
            double fuel,
            int ownerId,
            string factionId,
            bool lockDoors,
            string licensePlate
        )
        {
            Id = id;
            Model = model;
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
