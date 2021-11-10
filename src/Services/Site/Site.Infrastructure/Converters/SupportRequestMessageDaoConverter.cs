using CountyRP.Services.Site.Infrastructure.Entities;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.Infrastructure.Converters
{
    public static class SupportRequestMessageDaoConverter
    {
        public static SupportRequestMessageDtoOut ToRepository(
            SupportRequestMessageDao source
        )
        {
            return new SupportRequestMessageDtoOut(
                Id: source.Id,
                TopicId: source.TopicId,
                Text: source.Text,
                UserId: source.UserId,
                CreationDate: source.CreationDate,
                EditionDate: source.EditionDate
            );
        }
    }
}
