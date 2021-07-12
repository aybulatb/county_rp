using System;

namespace CountyRP.Services.Forum.API.Models.Api
{
    public class ApiPostFilterDtoIn : ApiPagedFilter
    {
        public string Text { get; set; }

        public int UserId { get; set; }

        public DateTimeOffset CreationDateTime { get; set; }

        public DateTimeOffset EditionDateTime { get; set; }
    }
}
