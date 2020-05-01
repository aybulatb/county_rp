using CountyRP.Models;

namespace CountyRP.WebAPI.Extensions
{
    public static class VehicleExtension
    {
        public static Entities.Vehicle Format(this Entities.Vehicle v1, Vehicle v2)
        {
            v1.Id = v2.Id;
            v1.Model = v2.Model;
            v1.Position = v2.Position;
            v1.Rotation = v2.Rotation;
            v1.Dimension = v2.Dimension;
            v1.Color1 = v2.Color1;
            v1.Color2 = v2.Color2;
            v1.Fuel = v2.Fuel;
            v1.OwnerId = v2.OwnerId;
            v1.FactionId = v2.FactionId;
            v1.Lock = v2.Lock;
            v1.LicensePlate = v2.LicensePlate;

            return v1;
        }

        public static Vehicle Format(this Vehicle v1, Entities.Vehicle v2)
        {
            v1.Id = v2.Id;
            v1.Model = v2.Model;
            v1.Position = v2.Position;
            v1.Rotation = v2.Rotation;
            v1.Dimension = v2.Dimension;
            v1.Color1 = v2.Color1;
            v1.Color2 = v2.Color2;
            v1.Fuel = v2.Fuel;
            v1.OwnerId = v2.OwnerId;
            v1.FactionId = v2.FactionId;
            v1.Lock = v2.Lock;
            v1.LicensePlate = v2.LicensePlate;

            return v1;
        }
    }
}
