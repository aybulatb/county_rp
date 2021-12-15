using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Infrastructure.Models.Ban;

namespace CountyRP.Services.Game.Infrastructure.Converters.Ban
{
    internal static class BanDtoOutConverter
    {
        public static BanDao ToDb(
            BanDtoOut source
        )
        {
            return new BanDao();
        }
    }
}
