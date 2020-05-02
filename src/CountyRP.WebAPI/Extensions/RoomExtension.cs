using CountyRP.Models;

namespace CountyRP.WebAPI.Extensions
{
    public static class RoomExtension
    {
        public static Entities.Room Format(this Entities.Room r1, Room r2)
        {
            r1.Id = r2.Id;
            r1.Name = r2.Name;
            r1.EntrancePosition = r2.EntrancePosition;
            r1.EntranceDimension = r2.EntranceDimension;
            r1.ExitPosition = r2.ExitPosition;
            r1.ExitDimension = r2.ExitDimension;
            r1.TypeMarker = r2.TypeMarker;
            r1.ColorMarker = (int[])r2.ColorMarker.Clone();
            r1.TypeBlip = r2.TypeBlip;
            r1.ColorBlip = r2.ColorBlip;
            r1.GroupId = r2.GroupId;
            r1.Lock = r2.Lock;
            r1.Price = r2.Price;
            r1.LastPayment = r2.LastPayment;
            r1.SafePosition = (float[])r2.SafePosition.Clone();
            r1.SafeDimension = r2.SafeDimension;

            return r1;
        }

        public static Room Format(this Room r1, Entities.Room r2)
        {
            r1.Id = r2.Id;
            r1.Name = r2.Name;
            r1.EntrancePosition = r2.EntrancePosition;
            r1.EntranceDimension = r2.EntranceDimension;
            r1.ExitPosition = r2.ExitPosition;
            r1.ExitDimension = r2.ExitDimension;
            r1.TypeMarker = r2.TypeMarker;
            r1.ColorMarker = (int[])r2.ColorMarker.Clone();
            r1.TypeBlip = r2.TypeBlip;
            r1.ColorBlip = r2.ColorBlip;
            r1.GroupId = r2.GroupId;
            r1.Lock = r2.Lock;
            r1.Price = r2.Price;
            r1.LastPayment = r2.LastPayment;
            r1.SafePosition = (float[])r2.SafePosition.Clone();
            r1.SafeDimension = r2.SafeDimension;

            return r1;
        }
    }
}
