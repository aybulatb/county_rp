using CountyRP.Services.Site.Infrastructure.Entities;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.Infrastructure.Converters
{
    public static class SupportRequestMessageDtoOutConverter
    {
        public static SupportRequestMessageDao ToDb(
            SupportRequestMessageDtoOut source
        )
        {
            return new SupportRequestMessageDao(
                id: source.Id,
                topicId: source.TopicId,
                text: source.Text,
                userId: source.UserId,
                creationDate: source.CreationDate,
                editionDate: source.EditionDate
            );
        }
    }
}
