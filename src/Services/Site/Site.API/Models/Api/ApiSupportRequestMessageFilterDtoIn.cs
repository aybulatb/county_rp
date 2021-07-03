using System.Collections.Generic;

namespace CountyRP.Services.Site.API.Models.Api
{
    public class ApiSupportRequestMessageFilterDtoIn : ApiPagedFilter
    {
        public IList<int> Ids { get; set; }

        public int? TopicId { get; set; }

        public int? UserId { get; set; }
    }
}
