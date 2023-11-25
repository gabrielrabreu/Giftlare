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
            if (exception is DetailedException detailedException)
                await TreatExceptionAsync(httpContext, detailedException);
            else
                await TreatExceptionAsync(httpContext, exception);
        }

        private static async Task TreatExceptionAsync(HttpContext httpContext, DetailedException detailedException)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            var response = new
            {
                type = detailedException.Type,
                error = detailedException.Error,
                detail = detailedException.Detail,
                instance = httpContext.Request.Path.Value,
                traceId = Activity.Current?.TraceId.ToString()
            };
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private static async Task TreatExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            var response = new
            {
                type = "InternalServerError",
                error = "InternalServerError",
                detail = exception.Message,
                instance = httpContext.Request.Path.Value,
                traceId = Activity.Current?.TraceId.ToString()
            };
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
