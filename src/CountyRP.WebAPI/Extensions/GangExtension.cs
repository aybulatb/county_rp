using CountyRP.Models;

namespace CountyRP.WebAPI.Extensions
{
    public static class GangExtension
    {
        public static Entities.Gang Format(this Entities.Gang g1, Gang g2)
        {
            g1.Id = g2.Id;
            g1.Name = g2.Name;
            g1.Color = g2.Color;
            g1.Ranks = (string[])g2.Ranks.Clone();
            g1.Type = g2.Type;

            return g1;
        }

        public static Gang Format(this Gang g1, Entities.Gang g2)
        {
            g1.Id = g2.Id;
            g1.Name = g2.Name;
            g1.Color = g2.Color;
            g1.Ranks = (string[])g2.Ranks.Clone();
            g1.Type = g2.Type;

            return g1;
        }
    }
}
