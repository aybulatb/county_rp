using CountyRP.Models;

namespace CountyRP.WebAPI.Extensions
{
    public static class PlayerExtension
    {
        public static Entities.Player Format(this Entities.Player p1, Player p2)
        {
            p1.Id = p2.Id;
            p1.Login = p2.Login;
            p1.Password = p2.Password;
            p1.GroupId = p2.GroupId;

            return p1;
        }

        public static Player Format(this Player p1, Entities.Player p2)
        {
            p1.Id = p2.Id;
            p1.Login = p2.Login;
            p1.Password = p2.Password;
            p1.GroupId = p2.GroupId;

            return p1;
        }
    }
}
