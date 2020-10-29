using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;

namespace CountyRP.WebAPI.Extensions
{
    public static class APIKeyExtension
    {
        public static IApplicationBuilder UseAPIKeys(this IApplicationBuilder builder, IEnumerable<string> apiKeys)
        {
            return builder.UseMiddleware<APIKeyMiddleware>(apiKeys);
        }
    }
}
