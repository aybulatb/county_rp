namespace CountyRP.ApiGateways.AdminPanel.API.Models.Api
{
    public record ApiErrorResponseDtoOut(
        ApiErrorCodeDto Code,
        string Message
    );
}
