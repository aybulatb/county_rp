using CountyRP.Models;

namespace CountyRP.WebAPI.Extensions
{
    public static class HouseExtension
    {
        public static Entities.House Format(this Entities.House h1, House h2)
        {
            h1.Id = h2.Id;
            h1.EntrancePosition = h2.EntrancePosition;
            h1.EntranceDimension = h2.EntranceDimension;
            h1.ExitPosition = h2.ExitPosition;
            h1.ExitDimension = h2.ExitDimension;
            h1.OwnerId = h2.OwnerId;
            h1.Lock = h2.Lock;
            h1.Price = h2.Price;           

            return h1;
        }

        public static House Format(this House h1, Entities.House h2)
        {
            h1.Id = h2.Id;
            h1.EntrancePosition = h2.EntrancePosition;
            h1.EntranceDimension = h2.EntranceDimension;
            h1.ExitPosition = h2.ExitPosition;
            h1.ExitDimension = h2.ExitDimension;
            h1.OwnerId = h2.OwnerId;
            h1.Lock = h2.Lock;
            h1.Price = h2.Price;

            return h1;
        }
    }
}
