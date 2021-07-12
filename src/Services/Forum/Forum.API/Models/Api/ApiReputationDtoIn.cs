using System;

namespace CountyRP.Services.Forum.API.Models.Api
{
    public class ApiReputationDtoIn
    {
        public int UserId { get; set; }

        public int ChangedByUserId { get; set; }

        public DateTimeOffset DateTime { get; set; }

        public int Action { get; set; }

        public string Text { get; set; }
    }
}
