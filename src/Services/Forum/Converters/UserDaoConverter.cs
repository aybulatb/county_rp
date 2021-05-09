using CountyRP.Services.Forum.Entities;
using CountyRP.Services.Forum.Models;

namespace CountyRP.Services.Forum.Converters
{
    internal static class UserDaoConverter
    {
        public static UserDtoOut ToRepository(
            UserDao source
        )
        {
            return new UserDtoOut(
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
