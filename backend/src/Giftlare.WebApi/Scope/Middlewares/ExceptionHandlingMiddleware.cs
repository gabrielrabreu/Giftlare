using Giftlare.Core.Domain.Exceptions;
using System.Diagnostics;
using System.Text.Json;

namespace Giftlare.WebApi.Scope.Middlewares
{
    internal sealed class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) => _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            if (exception is GiftlareException detailedException)
                await TreatExceptionAsync(httpContext, detailedException);
            else
                await TreatExceptionAsync(httpContext, exception);
        }

        private static async Task TreatExceptionAsync(HttpContext httpContext, GiftlareException detailedException)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            var response = new ErrorResponseDto
            {
                Type = detailedException.Type,
                Error = detailedException.Error,
                Detail = detailedException.Detail,
                Instance = httpContext.Request.Path.Value,
                TraceId = Activity.Current?.TraceId.ToString()
            };
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private static async Task TreatExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            var response = new ErrorResponseDto
            {
                Type = "InternalServerError",
                Error = "InternalServerError",
                Detail = exception.Message,
                Instance = httpContext.Request.Path.Value,
                TraceId = Activity.Current?.TraceId.ToString()
            };
            await httpContext.Response.WriteAsync(response.Serialize());
        }
    }
}
