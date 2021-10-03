namespace CountyRP.Services.Logs.API.Models.Api
{
    public class ApiErrorResponseDtoOut
    {
        public ApiErrorCodeDto Code { get; }

        public string Message { get; }

        public ApiErrorResponseDtoOut(
            ApiErrorCodeDto code,
            string message
        )
        {
            Code = code;
            Message = message;
        }
    }
}
