using CountyRP.Models;

namespace CountyRP.WebAPI.Extensions
{
    public static class BusinessExtension
    {
        public static Entities.Business Format(this Entities.Business b1, Business b2)
        {
            b1.Id = b2.Id;
            b1.Name = b2.Name;
            b1.EntrancePosition = (float[])b2.EntrancePosition.Clone();
            b1.EntranceDimension = b2.EntranceDimension;
            b1.ExitPosition = (float[])b2.ExitPosition.Clone();
            b1.ExitDimension = b2.ExitDimension;
            b1.OwnerId = b2.OwnerId;
            b1.Lock = b2.Lock;
            b1.Type = b2.Type;
            b1.Price = b2.Price;

            return b1;
        }

        public static Business Format(this Business b1, Entities.Business b2)
        {
            b1.Id = b2.Id;
            b1.Name = b2.Name;
            b1.EntrancePosition = (float[])b2.EntrancePosition.Clone();
            b1.EntranceDimension = b2.EntranceDimension;
            b1.ExitPosition = (float[])b2.ExitPosition.Clone();
            b1.ExitDimension = b2.ExitDimension;
            b1.OwnerId = b2.OwnerId;
            b1.Lock = b2.Lock;
            b1.Type = b2.Type;
            b1.Price = b2.Price;

            return b1;
        }
    }
}
