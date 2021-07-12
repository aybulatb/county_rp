using System.Collections.Generic;

namespace CountyRP.Services.Forum.API.Models.Api
{
    public class ApiPagedFilterResult<T>
    {
        public int AllCount { get; set; }

        public int Page { get; set; }

        public int MaxPages { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}
