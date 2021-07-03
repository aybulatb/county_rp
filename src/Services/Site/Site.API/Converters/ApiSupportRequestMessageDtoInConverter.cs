using CountyRP.Services.Site.API.Models.Api;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.API.Converters
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
