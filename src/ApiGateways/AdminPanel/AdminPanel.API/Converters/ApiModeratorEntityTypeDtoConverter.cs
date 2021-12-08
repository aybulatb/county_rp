using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters
{
    internal static class ApiModeratorEntityTypeDtoConverter
    {
        public static ForumModeratorEntityTypeDto ToService(
            ApiModeratorEntityTypeDto source
        )
        {
            return source switch
            {
                ApiModeratorEntityTypeDto.Group => ForumModeratorEntityTypeDto.Group,
                ApiModeratorEntityTypeDto.User => ForumModeratorEntityTypeDto.User,

                _ => ForumModeratorEntityTypeDto.Unknown
            };
        }
    }
}
