using CountyRP.Services.Forum.Infrastructure.Entities;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.Infrastructure.Converters
{
    internal static class ModeratorEntityTypeDtoConverter
    {
        public static ModeratorEntityTypeDao ToDb(
            ModeratorEntityTypeDto source
        )
        {
            return source switch
            {
                ModeratorEntityTypeDto.Group => ModeratorEntityTypeDao.Group,
                ModeratorEntityTypeDto.User => ModeratorEntityTypeDao.User,

                _ => ModeratorEntityTypeDao.Unknown
            };
        }
    }
}
