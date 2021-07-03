using CountyRP.Services.Site.Infrastructure.Entities;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.Infrastructure.Converters
{
    public static class SupportRequestMessageDtoInConverter
    {
        public static SupportRequestMessageDao ToDb(
            SupportRequestMessageDtoIn source
        )
        {
            return new SupportRequestMessageDao(
                id: 0,
                topicId: source.TopicId,
                text: source.Text,
                userId: source.UserId,
                creationDate: source.CreationDate,
                editionDate: source.EditionDate
            );
        }
    }
}
