using CountyRP.Services.Site.Entities;
using CountyRP.Services.Site.Models;
using CountyRP.Services.Site.Models.Api;

namespace CountyRP.Services.Site.Converters
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

        public static ApiSupportRequestMessageDtoOut ToApi(
            SupportRequestMessageDtoOut source
        )
        {
            return new ApiSupportRequestMessageDtoOut(
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
