using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models;
using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters
{
    internal static class ModeratorIdsConverter
    {
        public static ForumModeratorFilterDtoIn ToForumModeratorFilterDtoIn(
            IEnumerable<int> source
        )
        {
            return new ForumModeratorFilterDtoIn(
                Count: null,
                Page: null,
                Ids: source,
                EntityId: null,
                EntityType: null,
                ForumId: null
            );
        }
    }
}
