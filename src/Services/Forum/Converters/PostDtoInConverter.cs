using CountyRP.Services.Forum.Entities;
using CountyRP.Services.Forum.Models;

namespace CountyRP.Services.Forum.Converters
{
    internal static class PostDtoInConverter
    {
        public static PostDao ToDb(
            PostDtoIn source
        )
        {
            return new PostDao(
                id: 0,
                text: source.Text,
                topicId: source.TopicId,
                userId: source.UserId,
                lastEditorId: source.LastEditorid,
                creationDateTime: source.CreationDateTime,
                editionDateTime: source.EditionDateTime
            );
        }

        public static PostDtoOut ToDtoOut(
            PostDtoIn source,
            int id
        )
        {
            return new PostDtoOut(
                id: id,
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
