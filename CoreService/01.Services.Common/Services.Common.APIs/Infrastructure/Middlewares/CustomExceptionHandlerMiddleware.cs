using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;

namespace Services.Common.APIs.Infrastructure
{
    public static class CustomExceptionHandlerMiddleware
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionHandler>();
            return app;
        }
    }

    public class CustomExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandler> _logger;

        public CustomExceptionHandler(RequestDelegate next, ILogger<CustomExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleUnhandledExceptionAsync(httpContext, ex).ConfigureAwait(false);
            }
        }
        private async Task HandleUnhandledExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, exception.Message);
            if (!context.Response.HasStarted)
            {
                int statusCode;
                var result = new VoidMethodResult();
                context.Response.Clear();
                context.Response.ContentType = "application/json";
                if (exception.GetType().BaseType == typeof(BaseException))
                {
                    statusCode = (int)HttpStatusCode.BadRequest;
                    var baseException = (BaseException)exception;
                    result.AddErrorMessages(baseException.ErrorResultList);
                }
                else
                {
                    statusCode = (int)HttpStatusCode.InternalServerError; // 500
                    result.AddErrorMessage(ErrorHelpers.GetExceptionMessage(exception), exception.StackTrace);
                }
                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsync(result.ToJsonString()).ConfigureAwait(false);
            }
        }
    }
}