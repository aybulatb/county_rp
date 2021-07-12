using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters
{
    internal static class ApiUserDtoInConverter
    {
        public static UserDtoIn ToRepository(
            ApiUserDtoIn source
        )
        {
            return new UserDtoIn(
                login: source.Login,
                groupId: source.GroupId,
                reputation: source.Reputation,
                posts: source.Posts,
                warnings: source.Warnings
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
                groupId: source.GroupId,
                reputation: source.Reputation,
                posts: source.Posts,
                warnings: source.Warnings
            );
        }
    }
}
