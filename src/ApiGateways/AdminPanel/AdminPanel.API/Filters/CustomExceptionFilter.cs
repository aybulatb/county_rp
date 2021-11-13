using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Exceptions;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace CountyRP.ApiGateways.AdminPanel.API.Filters
{
    public class CustomExceptionFilter : Attribute, IExceptionFilter
    {
        private readonly ILogger<CustomExceptionFilter> _logger;

        public CustomExceptionFilter(
            ILogger<CustomExceptionFilter> logger
        )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void OnException(ExceptionContext context)
        {
            ApiErrorResponseDtoOut error;

            if (context.Exception.GetType() == typeof(ServiceException<ServiceErrorResponseDtoOut>))
            {
                var serviceException = context.Exception as ServiceException<ServiceErrorResponseDtoOut>;
                error = new ApiErrorResponseDtoOut(
                    Code: ApiErrorCodeDto.Unknown,
                    Message: serviceException.Response.Message
                );
            }
            else
            {
                error = new ApiErrorResponseDtoOut(
                    Code: ApiErrorCodeDto.Unknown,
                    Message: "Произошла непредвиденная ошибка"
                );

                _logger.LogError($"{context.Exception.Message}{Environment.NewLine}{context.Exception.StackTrace}");
            }

            context.Result = new BadRequestObjectResult(error);
            context.ExceptionHandled = true;
        }
    }
}
