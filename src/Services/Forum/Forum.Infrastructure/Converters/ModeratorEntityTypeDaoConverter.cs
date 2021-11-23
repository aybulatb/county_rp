using CountyRP.Services.Forum.Infrastructure.Entities;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.Infrastructure.Converters
{
    internal static class ModeratorEntityTypeDaoConverter
    {
        public static ModeratorEntityTypeDto ToRepository(
            ModeratorEntityTypeDao source
        )
        {
            return source switch
            {
                ModeratorEntityTypeDao.Group => ModeratorEntityTypeDto.Group,
                ModeratorEntityTypeDao.User => ModeratorEntityTypeDto.User,

                _ => ModeratorEntityTypeDto.Unknown
            };
        }
    }
}
