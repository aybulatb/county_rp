using CountyRP.Services.Site.Models;
using CountyRP.Services.Site.Models.Api;

namespace CountyRP.Services.Site.Converters
{
    internal static class ApiUserDtoInConverter
    {
        public static UserDtoIn ToRepository(
            ApiUserDtoIn source
        )
        {
            return new UserDtoIn(
                login: source.Login,
                password: source.Password,
                playerId: source.PlayerId,
                forumUserId: source.ForumUserId,
                groupId: source.GroupId
            );
        }

        public static UserDtoOut ToDtoOut(
           ApiUserDtoIn source,
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
