using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Models.Api;

namespace CountyRP.Services.Forum.Converters
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
    }
}
