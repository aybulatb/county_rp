using System.Collections.Generic;

namespace CountyRP.Services.Forum.API.Models.Api
{
    public class ApiForumFilterDtoIn : ApiPagedFilter
    {
        public IEnumerable<int> ParentIds { get; init; }
    }
}
