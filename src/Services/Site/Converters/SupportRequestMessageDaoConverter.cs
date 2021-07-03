using CountyRP.Services.Site.Entities;
using CountyRP.Services.Site.Models;

namespace CountyRP.Services.Site.Converters
{
    public static class SupportRequestMessageDaoConverter
    {
        public static SupportRequestMessageDtoOut ToRepository(
            SupportRequestMessageDao source
        )
        {
            return new SupportRequestMessageDtoOut(
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
