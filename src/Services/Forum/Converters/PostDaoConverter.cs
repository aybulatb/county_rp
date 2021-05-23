using CountyRP.Services.Forum.Entities;
using CountyRP.Services.Forum.Models;

namespace CountyRP.Services.Forum.Converters
{
    internal static class PostDaoConverter
    {
        public static PostDtoOut ToRepository(
            PostDao source
        )
        {
            return new PostDtoOut(
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
