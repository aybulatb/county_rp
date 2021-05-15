using CountyRP.Services.Forum.Entities;
using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Models.Api;

namespace CountyRP.Services.Forum.Converters
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
                groupId: source.GroupId,
                reputation: source.Reputation,
                posts: source.Posts,
                warnings: source.Warnings
            );
        }
        public static ApiUserDtoOut ToApi(
            UserDtoOut source
        )
        {
            return new ApiUserDtoOut()
            {
                Id = source.Id,
                Login = source.Login,
                GroupId = source.GroupId,
                Reputation = source.Reputation,
                Posts = source.Posts,
                Warnings = source.Warnings
            };
        }
    }
}
