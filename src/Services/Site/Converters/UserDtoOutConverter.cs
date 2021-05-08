using CountyRP.Services.Site.Entities;
using CountyRP.Services.Site.Models;
using CountyRP.Services.Site.Models.Api;

namespace CountyRP.Services.Site.Converters
{
    internal static class UserDtoOutConverter
    {
        public static UserDao ToDb(
            UserDtoOut source
        )
        {
            return new UserDao(
                id: source.Id,
                login: source.Login,
                password: source.Password,
                playerId: source.PlayerId,
                forumUserId: source.ForumUserId,
                groupId: source.GroupId
            );
        }

        public static ApiUserDtoOut ToApi(
            UserDtoOut source
        )
        {
            return new ApiUserDtoOut(
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
