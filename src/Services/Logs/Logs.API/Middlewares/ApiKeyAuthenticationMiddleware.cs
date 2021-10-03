using CountyRP.Services.Logs.API.Settings;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CountyRP.Services.Logs.API.Middlewares
{
    public class ApiKeyAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IEnumerable<ApiKeySettings> _apiKeys;

        public ApiKeyAuthenticationMiddleware(
            RequestDelegate next,
            IEnumerable<ApiKeySettings> apiKeys
        )
        {
            _next = next;
            _apiKeys = apiKeys;
        }

        public async Task InvokeAsync(
            HttpContext context
        )
        {
            context.Request.Headers.TryGetValue("Authorization", out var token);
            var tokenString = token.ToString();

            var match = Regex.Match(tokenString, "Bearer (?<token>.+)");
            var apiKeyString = match.Groups.GetValueOrDefault("token");

            if (_apiKeys.Any(apiKey => apiKey.Key == apiKeyString?.Value))
            {
                await _next.Invoke(context);
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
        }
    }
}
