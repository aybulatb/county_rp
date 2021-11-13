using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Converters;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Implementations
{
    public partial class GameService
    {
        public async Task<GamePlayerWithPersonsDtoOut> GetPlayerWithPersonsByPlayerIdAsync(int playerId)
        {
            var playerWithPersons = await _playerWithPersonsClient.GetByIdAsync(playerId);

            return ApiPlayerWithPersonsDtoOutConverter.ToService(playerWithPersons);
        }

        public async Task<GamePagedFilterResultDtoOut<GamePlayerWithPersonsDtoOut>> GetPlayersWithPersonsByFilterAsync(
            GamePlayerWithPersonsFilterDtoIn filter
        )
        {
            var playersWithPersons = await _playerWithPersonsClient.FilterByAsync(
                ids: filter.Ids,
                logins: filter.Logins,
                partOfLogin: null,
                startRegistrationDate: filter.StartRegistrationDate,
                finishRegistrationDate: filter.FinishRegistrationDate,
                startLastVisitDate: filter.StartLastVisitDate,
                finishLastVisitDate: filter.FinishLastVisitDate,
                personsIds: filter.PersonsIds,
                personsNames: filter.PersonsNames,
                personNameLike: filter.PersonNameLike,
                adminLevelIds: filter.AdminLevelIds,
                factionIds: filter.FactionIds,
                count: filter.Count,
                page: filter.Page
            );

            return GameApiPagedFilterResultDtoOutConverter.ToService(playersWithPersons);
        }
    }
}
