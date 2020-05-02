using CountyRP.Models;

namespace CountyRP.WebAPI.Extensions
{
    public static class LockerRoomExtension
    {
        public static Entities.LockerRoom Format(this Entities.LockerRoom lr1, LockerRoom lr2)
        {
            lr1.Id = lr2.Id;
            lr1.Position = (float[])lr2.Position.Clone();
            lr1.Dimension = lr2.Dimension;
            lr1.TypeMarker = lr2.TypeMarker;
            lr1.ColorMarker = (int[])lr2.ColorMarker.Clone();
            lr1.FactionId = lr2.FactionId;

            return lr1;
        }

        public static LockerRoom Format(this LockerRoom lr1, Entities.LockerRoom lr2)
        {
            lr1.Id = lr2.Id;
            lr1.Position = (float[])lr2.Position.Clone();
            lr1.Dimension = lr2.Dimension;
            lr1.TypeMarker = lr2.TypeMarker;
            lr1.ColorMarker = (int[])lr2.ColorMarker.Clone();
            lr1.FactionId = lr2.FactionId;

            return lr1;
        }
    }
}
