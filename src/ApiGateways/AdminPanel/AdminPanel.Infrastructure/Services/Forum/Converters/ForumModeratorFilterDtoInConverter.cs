using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClients.ServiceForum;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models;
using System.Linq;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Converters
{
    internal static class ForumModeratorFilterDtoInConverter
    {
        public static ApiModeratorFilterDtoIn ToExternalApi(
            ForumModeratorFilterDtoIn source
        )
        {
            return new ApiModeratorFilterDtoIn
            {
                Count = source.Count,
                Page = source.Page,
                Ids = source.Ids.ToList(),
                EntityId = source.EntityId,
                EntityType = (int)source.EntityType,
                ForumId = source.ForumId
            };
        }
    }
}
