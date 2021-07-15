using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiEditedPlayerDtoInConverter
    {
        public static EditedPlayerDtoIn ToRepository(
            ApiEditedPlayerDtoIn source,
            int id
        )
        {
            return new EditedPlayerDtoIn(
                id: id,
                login: source.Login,
                password: source.Password,
                lastVisitDate: source.LastVisitDate
            );
        }
    }
}
