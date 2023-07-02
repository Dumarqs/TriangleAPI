namespace TriangleAPI.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ILoggerAdapter<ErrorHandlerMiddleware> _logger;
        //public ErrorHandlerMiddleware(RequestDelegate next, ILoggerAdapter<ErrorHandlerMiddleware> logger)
        //{
        //    _next = next;
        //    _logger = logger;
        //}

        //public async Task InvokeAsync(HttpContext httpContext)
        //{
        //    try
        //    {
        //        await _next(httpContext);
        //    }
        //    catch (Exception ex)
        //    {
        //        await HandleExceptionAsync(httpContext, ex);
        //    }
        //}
        //private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        //{ 
        //}
    }
}
