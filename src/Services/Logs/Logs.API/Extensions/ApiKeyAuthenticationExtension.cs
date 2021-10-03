using CountyRP.Services.Logs.API.Middlewares;
using CountyRP.Services.Logs.API.Settings;
using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;

namespace CountyRP.Services.Logs.API.Extensions
{
    public static class ApiKeyAuthenticationExtension
    {
        public static IApplicationBuilder UseApiKeyAuthentication(
            this IApplicationBuilder builder,
            IEnumerable<ApiKeySettings> apiKeys
        )
        {
            return builder.UseMiddleware<ApiKeyAuthenticationMiddleware>(apiKeys);
        }
    }
}
