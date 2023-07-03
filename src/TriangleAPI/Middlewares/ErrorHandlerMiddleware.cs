using Infra.CrossCutting.Logging.Interfaces;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace TriangleAPI.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerAdapter<ErrorHandlerMiddleware> _logger;
        public ErrorHandlerMiddleware(RequestDelegate next, ILoggerAdapter<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int code;
            var result = exception.Message;

            switch (exception)
            {
                case ValidationException validationException:
                    code = (int)HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationException.ValidationResult);
                    break;
                case BadHttpRequestException badRequestException:
                    code = (int)HttpStatusCode.BadRequest;
                    result = badRequestException.Message;
                    break;
                case ApplicationException applicationException:
                    code = (int)HttpStatusCode.Forbidden;
                    result = applicationException.Message;
                    break;
                case KeyNotFoundException keyNotFoundException:
                    code = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    code = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            _logger.LogError(exception, result);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;

            await context.Response.WriteAsync(JsonConvert.SerializeObject(new { StatusCode = code, ErrorMessage = exception.Message }));
        }
    }
}
