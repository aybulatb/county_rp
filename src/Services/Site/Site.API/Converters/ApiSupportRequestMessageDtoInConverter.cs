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
                TopicId: source.TopicId,
                Text: source.Text,
                UserId: source.UserId,
                CreationDate: source.CreationDate,
                EditionDate: source.EditionDate
            );
        }
    }
}
