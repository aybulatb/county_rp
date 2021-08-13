using CountyRP.ApiGateways.AdminPanel.Infrastructure.Models;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceGame;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Converters
{
    public static class ApiErrorResponseDtoOutConverter
    {
        public static ServiceErrorResponseDtoOut ToService(
            ApiErrorResponseDtoOut source
        )
        {
            return new ServiceErrorResponseDtoOut(
                code: ApiErrorCodeDtoConverter.ToService(source.Code),
                message: source.Message
            );
        }
    }
}
