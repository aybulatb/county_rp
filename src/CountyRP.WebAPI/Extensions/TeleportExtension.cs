using CountyRP.Models;

namespace CountyRP.WebAPI.Extensions
{
    public static class TeleportExtension
    {
        public static Entities.Teleport Format(this Entities.Teleport t1, Teleport t2)
        {
            t1.Id = t2.Id;
            t1.Name = t2.Name;
            t1.EntrancePosition = (float[])t2.EntrancePosition.Clone();
            t1.EntranceDimension = t2.EntranceDimension;
            t1.ExitPosition = (float[])t2.ExitPosition.Clone();
            t1.ExitDimension = t2.ExitDimension;
            t1.TypeMarker = t2.TypeMarker;
            t1.ColorMarker = (int[])t2.ColorMarker.Clone();
            t1.TypeBlip = t2.TypeBlip;
            t1.ColorBlip = t2.ColorBlip;
            t1.FactionId = t2.FactionId;
            t1.GangId = t2.GangId;
            t1.RoomId = t2.RoomId;
            t1.Lock = t2.Lock;

            return t1;
        }

        public static Teleport Format(this Teleport t1, Entities.Teleport t2)
        {
            t1.Id = t2.Id;
            t1.Name = t2.Name;
            t1.EntrancePosition = (float[])t2.EntrancePosition.Clone();
            t1.EntranceDimension = t2.EntranceDimension;
            t1.ExitPosition = (float[])t2.ExitPosition.Clone();
            t1.ExitDimension = t2.ExitDimension;
            t1.TypeMarker = t2.TypeMarker;
            t1.ColorMarker = (int[])t2.ColorMarker.Clone();
            t1.TypeBlip = t2.TypeBlip;
            t1.ColorBlip = t2.ColorBlip;
            t1.FactionId = t2.FactionId;
            t1.GangId = t2.GangId;
            t1.RoomId = t2.RoomId;
            t1.Lock = t2.Lock;

            return t1;
        }
    }
}
