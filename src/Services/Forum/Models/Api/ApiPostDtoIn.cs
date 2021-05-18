using System;

namespace CountyRP.Services.Forum.Models.Api
{
    public class ApiPostDtoIn
    {
        public string Text { get; set; }

        public int TopicId { get; set; }

        public int UserId { get; set; }

        public int LastEditorid { get; set; }

        public DateTimeOffset CreationDateTime { get; set; }

        public DateTimeOffset EditionDateTime { get; set; }
    }
}
