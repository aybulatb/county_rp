namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiErrorResponseDtoOut
    {
        public ApiErrorCodeDto Code { get; init; }

        public string Message { get; init; }

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
