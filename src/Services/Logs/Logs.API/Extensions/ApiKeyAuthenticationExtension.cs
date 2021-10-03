using CountyRP.Services.Logs.API.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace CountyRP.Services.Logs.API.Extensions
{
    public static class ApiKeyAuthenticationExtension
    {
        public static IApplicationBuilder UseApiKeyAuthentication(
            this IApplicationBuilder builder
        )
        {
            return builder.UseMiddleware<ApiKeyAuthenticationMiddleware>();
        }
    }
}
