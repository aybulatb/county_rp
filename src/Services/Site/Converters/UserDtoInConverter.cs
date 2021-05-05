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
            return ToDb(0, source);
        }

        public static UserDao ToDb(
            int id,
            UserDtoIn source
        )
        {
            return new UserDao(
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
