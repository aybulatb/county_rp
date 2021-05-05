using CountyRP.Services.Site.Entities;
using CountyRP.Services.Site.Models;

namespace CountyRP.Services.Site.Converters
{
    internal static class UserDaoConverter
    {
        public static UserDtoOut ToRepository(
            UserDao source
        )
        {
            return new UserDtoOut(
                id: source.Id,
                login: source.Login,
                password: source.Password,
                playerId: source.PlayerId,
                forumUserId: source.ForumUserId,
                groupId: source.GroupId
            );
        }
    }
}
