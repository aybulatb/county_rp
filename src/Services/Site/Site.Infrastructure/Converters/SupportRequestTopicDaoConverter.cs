using CountyRP.Services.Site.Infrastructure.Entities;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.Infrastructure.Converters
{
    public static class SupportRequestTopicDaoConverter
    {
        public static SupportRequestTopicDtoOut ToRepository(
            SupportRequestTopicDao source
        )
        {
            return new SupportRequestTopicDtoOut(
                Id: source.Id,
                Type: SupportRequestTopicTypeDaoConverter.ToRepository(source.Type),
                Caption: source.Caption,
                Status: SupportRequestTopicStatusDaoConverter.ToRepository(source.Status),
                CreatorUserId: source.CreatorUserId,
                CreationDate: source.CreationDate,
                RefUserId: source.RefUserId,
                ShowRefUser: source.ShowRefUser
            );
        }
    }
}
