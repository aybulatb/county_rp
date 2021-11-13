using CountyRP.ApiGateways.AdminPanel.Infrastructure.Converters;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Exceptions;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Models;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceGame;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Converters;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Implementations
{
    public partial class GameService
    {
        public async Task<GamePagedFilterResultDtoOut<GamePersonDtoOut>> GetPersonsByFilterAsync(
            GamePersonFilterDtoIn gamePersonFilterDtoIn
        )
        {
            try
            {
                var gameApiPagedPersonsDtoOut = await _personClient.FilterByAsync(
                    ids: gamePersonFilterDtoIn.Ids,
                    names: gamePersonFilterDtoIn.Names,
                    nameLike: gamePersonFilterDtoIn.NameLike,
                    playerIds: gamePersonFilterDtoIn.PlayerIds,
                    startRegistrationDate: gamePersonFilterDtoIn.StartRegistrationDate,
                    finishRegistrationDate: gamePersonFilterDtoIn.FinishRegistrationDate,
                    startLastVisitDate: gamePersonFilterDtoIn.StartLastVisitDate,
                    finishLastVisitDate: gamePersonFilterDtoIn.FinishRegistrationDate,
                    adminLevelIds: gamePersonFilterDtoIn.AdminLevelIds,
                    factionIds: gamePersonFilterDtoIn.FactionIds,
                    gangIds: gamePersonFilterDtoIn.GangIds,
                    leader: gamePersonFilterDtoIn.Leader,
                    rank: gamePersonFilterDtoIn.Rank,
                    count: gamePersonFilterDtoIn.Count,
                    page: gamePersonFilterDtoIn.Page
                );

                return GameApiPagedFilterResultDtoOutConverter.ToService(
                    gameApiPagedPersonsDtoOut
                );
            }
            catch (ApiException<ApiErrorResponseDtoOut> ex)
            {
                throw new ServiceException<ServiceErrorResponseDtoOut>(
                    message: ex.Message,
                    statusCode: ex.StatusCode,
                    result: ApiErrorResponseDtoOutConverter.ToService(ex.Result)
                );
            }
            catch (ApiException ex)
            {
                throw new ServiceException(
                    message: ex.Message,
                    statusCode: ex.StatusCode
                );
            }
        }
    }
}
