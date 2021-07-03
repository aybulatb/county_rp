using CountyRP.Services.Site.Entities;
using CountyRP.Services.Site.Models;

namespace CountyRP.Services.Site.Converters
{
    public static class SupportRequestTopicDtoInConverter
    {
        public static SupportRequestTopicDao ToDb(
            SupportRequestTopicDtoIn source
        )
        {
            return new SupportRequestTopicDao(
                id: 0,
                type: SupportRequestTopicTypeDtoConverter.ToDb(source.Type),
                caption: source.Caption,
                status: SupportRequestTopicStatusDtoConverter.ToDb(source.Status),
                creatorUserId: source.CreatorUserId,
                creationDate: source.CreationDate,
                refUserId: source.RefUserId,
                showRefUser: source.ShowRefUser
            );
        }
    }
}
