using CountyRP.Services.Site.Entities;
using CountyRP.Services.Site.Models;

namespace CountyRP.Services.Site.Converters
{
    internal static class UserDtoInConverter
    {
        public static UserDao ToDb(
            UserDtoIn source
        )
        {
            return new UserDao(
                id: 0,
                login: source.Login,
                password: source.Password,
                playerId: source.PlayerId,
                forumUserId: source.ForumUserId,
                groupId: source.GroupId
            );
        }

        public static UserDtoOut ToDtoOut(
            UserDtoIn source,
            int id
        )
        {
            return new UserDtoOut(
                id: id,
                login: source.Login,
                password: source.Password,
                playerId: source.PlayerId,
                forumUserId: source.ForumUserId,
                groupId: source.GroupId
            );
        }
    }
}
