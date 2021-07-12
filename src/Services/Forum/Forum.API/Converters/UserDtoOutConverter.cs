using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters
{
    internal static class UserDtoOutConverter
    {
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
