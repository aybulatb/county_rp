using CountyRP.Services.Forum.Infrastructure.Entities;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.Infrastructure.Converters
{
    internal static class PostDtoOutConverter
    {
        public static PostDao ToDb(
            PostDtoOut source
        )
        {
            return new PostDao(
                id: source.Id,
                text: source.Text,
                topicId: source.TopicId,
                userId: source.UserId,
                lastEditorId: source.LastEditorid,
                creationDateTime: source.CreationDateTime,
                editionDateTime: source.EditionDateTime
            );
        }
    }
}
