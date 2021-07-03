using CountyRP.Services.Site.API.Models.Api;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.API.Converters
{
    public static class SupportRequestMessageDtoOutConverter
    {
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
