using CountyRP.Models;

namespace CountyRP.WebAPI.Extensions
{
    public static class PersonExtension
    {
        public static Entities.Person Format(this Entities.Person p1, Person p2)
        {
            p1.Id = p2.Id;
            p1.Name = p2.Name;
            p1.PlayerId = p2.PlayerId;
            p1.RegDate = p2.RegDate;
            p1.LastDate = p2.LastDate;
            p1.AdminLevelId = p2.AdminLevelId;
            p1.FactionId = p2.FactionId;
            p1.GroupId = p2.GroupId;
            p1.Leader = p2.Leader;
            p1.Rank = p2.Rank;
            p1.Position = p2.Position;

            return p1;
        }

        public static Person Format(this Person p1, Entities.Person p2)
        {
            p1.Id = p2.Id;
            p1.Name = p2.Name;
            p1.PlayerId = p2.PlayerId;
            p1.RegDate = p2.RegDate;
            p1.LastDate = p2.LastDate;
            p1.AdminLevelId = p2.AdminLevelId;
            p1.FactionId = p2.FactionId;
            p1.GroupId = p2.GroupId;
            p1.Leader = p2.Leader;
            p1.Rank = p2.Rank;
            p1.Position = p2.Position;

            return p1;
        }
    }
}
