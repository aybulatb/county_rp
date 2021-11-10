using CountyRP.Services.Site.Infrastructure.Entities;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.Infrastructure.Converters
{
    internal static class UserDaoConverter
    {
        public static UserDtoOut ToRepository(
            UserDao source
        )
        {
            return new UserDtoOut(
                Id: source.Id,
                Login: source.Login,
                Password: source.Password,
                RegistrationDate: source.RegistrationDate,
                LastVisitDate: source.LastVisitDate,
                PlayerId: source.PlayerId,
                ForumUserId: source.ForumUserId,
                GroupId: source.GroupId
            );
        }
    }
}
