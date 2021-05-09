using CountyRP.Services.Forum.Entities;
using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Models.Api;

namespace CountyRP.Services.Forum.Converters
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
                groupId: source.GroupId,
                reputation: source.Reputation,
                posts: source.Posts,
                warnings: source.Warnings
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
                groupId: source.GroupId,
                reputation: source.Reputation,
                posts: source.Posts,
                warnings: source.Warnings
            );
        }
    }
}
