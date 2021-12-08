using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters
{
    internal static class ForumIdConverter
    {
        public static ForumModeratorFilterDtoIn ToForumModeratorFilterDtoIn(
            int id
        )
        {
            return new ForumModeratorFilterDtoIn(
                Count: null,
                Page: null,
                Ids: null,
                EntityId: null,
                EntityType: null,
                ForumId: id
            );
        }
    }
}
