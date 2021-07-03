using CountyRP.Services.Site.Entities;
using CountyRP.Services.Site.Models;

namespace CountyRP.Services.Site.Converters
{
    public static class SupportRequestTopicDaoConverter
    {
        public static SupportRequestTopicDtoOut ToRepository(
            SupportRequestTopicDao source
        )
        {
            return new SupportRequestTopicDtoOut(
                id: source.Id,
                type: SupportRequestTopicTypeDaoConverter.ToRepository(source.Type),
                caption: source.Caption,
                status: SupportRequestTopicStatusDaoConverter.ToRepository(source.Status),
                creatorUserId: source.CreatorUserId,
                creationDate: source.CreationDate,
                refUserId: source.RefUserId,
                showRefUser: source.ShowRefUser
            );
        }
    }
}
