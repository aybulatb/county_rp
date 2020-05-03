using CountyRP.Models;

namespace CountyRP.WebAPI.Extensions
{
    public static class AdminLevelExtension
    {
        public static Entities.AdminLevel Format(this Entities.AdminLevel a1, AdminLevel a2)
        {
            a1.Id = a2.Id;
            a1.Name = a2.Name;
            a1.Ban = a2.Ban;

            return a1;
        }

        public static AdminLevel Format(this AdminLevel a1, Entities.AdminLevel a2)
        {
            a1.Id = a2.Id;
            a1.Name = a2.Name;
            a1.Ban = a2.Ban;

            return a1;
        }
    }
}
