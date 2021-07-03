using CountyRP.Services.Site.Models;
using CountyRP.Services.Site.Models.Api;

namespace CountyRP.Services.Site.Converters
{
    public static class ApiSupportRequestMessageDtoInConverter
    {
        public static SupportRequestMessageDtoIn ToRepository(
            ApiSupportRequestMessageDtoIn source
        )
        {
            return new SupportRequestMessageDtoIn(
                topicId: source.TopicId,
                text: source.Text,
                userId: source.UserId,
                creationDate: source.CreationDate,
                editionDate: source.EditionDate
            );
        }
    }
}
