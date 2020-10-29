using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CountyRP.WebAPI
{
    public class APIKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string[] _apiKeys;

        public APIKeyMiddleware(RequestDelegate next, IEnumerable<string> apiKeys)
        {
            _next = next;
            _apiKeys = apiKeys.ToArray();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.Headers.TryGetValue("api-key", out var value);
            var apiKey = value.FirstOrDefault();

            if (!_apiKeys.Contains(apiKey))
            {
                context.Response.StatusCode = 401;
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
