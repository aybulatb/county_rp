using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Infrastructure.Models.Ban;

namespace CountyRP.Services.Game.Infrastructure.Converters.Ban
{
    internal static class BanDtoInConverter
    {
        public static BanDao ToDb(
            BanDtoIn source
        )
        {
            return new BanDao();
        }
    }
}
