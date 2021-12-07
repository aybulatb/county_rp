using System.Collections.Generic;

namespace CountyRP.Services.Forum.API.Models.Api
{
    public class ApiModeratorFilterDtoIn : ApiPagedFilter
    {
        public IEnumerable<int> Ids { get; init; }

        public int? EntityId { get; init; }

        public int? EntityType { get; init; }

        public int? ForumId { get; init; }
    }
}
