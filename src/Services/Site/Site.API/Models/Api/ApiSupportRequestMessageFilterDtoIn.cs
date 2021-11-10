using System.Collections.Generic;

namespace CountyRP.Services.Site.API.Models.Api
{
    public record ApiSupportRequestMessageFilterDtoIn : ApiPagedFilter
    {
        public IList<int> Ids { get; init; }

        public int? TopicId { get; init; }

        public int? UserId { get; init; }
    }
}
