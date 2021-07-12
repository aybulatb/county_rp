using CountyRP.Services.Forum.Infrastructure.Entities;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.Infrastructure.Converters
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
