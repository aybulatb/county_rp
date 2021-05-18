using System;

namespace CountyRP.Services.Forum.Models
{
    public class PostFilterDtoIn : PagedFilter
    {
        public string Text { get; }

        public int UserId { get; }

        public DateTimeOffset CreationDateTime { get; }

        public DateTimeOffset EditionDateTime { get; }

        public PostFilterDtoIn(
            int count,
            int page,
            string text,
            DateTimeOffset creationDateTime,
            DateTimeOffset editionDateTime
        )
            : base(count, page)
        {
            Text = text;
            CreationDateTime = creationDateTime;
            EditionDateTime = editionDateTime;
        }
    }
}
