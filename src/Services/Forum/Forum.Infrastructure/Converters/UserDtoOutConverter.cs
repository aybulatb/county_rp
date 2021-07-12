using CountyRP.Services.Forum.Infrastructure.Entities;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.Infrastructure.Converters
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
    }
}
