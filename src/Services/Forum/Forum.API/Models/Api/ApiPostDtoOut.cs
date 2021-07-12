using System;

namespace CountyRP.Services.Forum.API.Models.Api
{
    public class ApiPostDtoOut
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int TopicId { get; set; }

        public int UserId { get; set; }

        public int LastEditorId { get; set; }

        public DateTimeOffset CreationDateTime { get; set; }

        public DateTimeOffset EditionDateTime { get; set; }
    }
}
