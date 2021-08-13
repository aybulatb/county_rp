using CountyRP.ApiGateways.AdminPanel.Infrastructure.Converters;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Exceptions;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Models;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceGame;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services
{
    public partial class GameService
    {
        public async Task<PlayerDtoOut> GetPlayerByIdAsync(int id)
        {
            try
            {
                var apiPlayerDtoOut = await _playerClient.GetByIdAsync(id);

                return ApiPlayerDtoOutConverter.ToService(
                    source: apiPlayerDtoOut
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
