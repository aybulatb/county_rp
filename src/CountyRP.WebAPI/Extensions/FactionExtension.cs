using CountyRP.Models;

namespace CountyRP.WebAPI.Extensions
{
    public static class FactionExtension
    {
        public static Entities.Faction Format(this Entities.Faction f1, Faction f2)
        {
            f1.Id = f2.Id;
            f1.Name = f2.Name;
            f1.Ranks = f2.Ranks;
            f1.Type = f2.Type;

            return f1;
        }

        public static Faction Format(this Faction f1, Entities.Faction f2)
        {
            f1.Id = f2.Id;
            f1.Name = f2.Name;
            f1.Ranks = f2.Ranks;
            f1.Type = f2.Type;

            return f1;
        }
    }
}
