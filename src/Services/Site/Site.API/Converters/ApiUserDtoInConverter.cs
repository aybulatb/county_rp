using CountyRP.Services.Site.API.Models.Api;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.API.Converters
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
