using CountyRP.Models;

namespace CountyRP.WebAPI.Extensions
{
    public static class GroupExtension
    {
        public static Entities.Group Format(this Entities.Group g1, Group g2)
        {
            g1.Id = g2.Id;
            g1.Name = g2.Name;
            g1.Color = g2.Color;
            g1.AdminPanel = g2.AdminPanel;

            return g1;
        }

        public static Group Format(this Group g1, Entities.Group g2)
        {
            g1.Id = g2.Id;
            g1.Name = g2.Name;
            g1.Color = g2.Color;
            g1.AdminPanel = g2.AdminPanel;

            return g1;
        }
    }
}
