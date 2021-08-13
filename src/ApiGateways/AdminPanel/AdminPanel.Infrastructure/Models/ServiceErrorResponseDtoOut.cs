namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Models
{
    public class ServiceErrorResponseDtoOut
    {
        public ServiceErrorCodeDto Code { get; }

        public string Message { get; }

        public ServiceErrorResponseDtoOut(
            ServiceErrorCodeDto code,
            string message
        )
        {
            Code = code;
            Message = message;
        }
    }
}
