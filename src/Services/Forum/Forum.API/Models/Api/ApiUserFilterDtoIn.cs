using System.Collections.Generic;

namespace CountyRP.Services.Forum.API.Models.Api
{
    public class ApiUserFilterDtoIn : ApiPagedFilter
    {
        public string Login { get; set; }

        public string SortingFlag { get; set; }

        public IEnumerable<string> GroupIds { get; set; }
    }
}
