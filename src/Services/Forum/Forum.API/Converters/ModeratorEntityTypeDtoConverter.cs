using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters
{
    internal static class ModeratorEntityTypeDtoConverter
    {
        public static ApiModeratorEntityTypeDto ToApi(
            ModeratorEntityTypeDto source
        )
        {
            return source switch
            {
                ModeratorEntityTypeDto.Group => ApiModeratorEntityTypeDto.Group,
                ModeratorEntityTypeDto.User => ApiModeratorEntityTypeDto.User,

                _ => ApiModeratorEntityTypeDto.Unknown
            };
        }
    }
}
