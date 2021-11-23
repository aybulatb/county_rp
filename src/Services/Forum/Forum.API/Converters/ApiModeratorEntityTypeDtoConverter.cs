using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters
{
    internal static class ApiModeratorEntityTypeDtoConverter
    {
        public static ModeratorEntityTypeDto ToRepository(
            ApiModeratorEntityTypeDto source
        )
        {
            return source switch
            {
                ApiModeratorEntityTypeDto.Group => ModeratorEntityTypeDto.Group,
                ApiModeratorEntityTypeDto.User => ModeratorEntityTypeDto.User,

                _ => ModeratorEntityTypeDto.Unknown
            };
        }
    }
}
