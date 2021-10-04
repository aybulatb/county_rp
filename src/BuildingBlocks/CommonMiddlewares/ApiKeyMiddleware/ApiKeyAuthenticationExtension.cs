using Microsoft.AspNetCore.Builder;

namespace CountyRP.BuildingBlocks.ApiKeyAuthenticationMiddleware
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
