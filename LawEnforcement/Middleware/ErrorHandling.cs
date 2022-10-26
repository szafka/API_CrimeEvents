using Microsoft.EntityFrameworkCore;

namespace LawEnforcement.Middleware
{
    public class ErrorHandling : IMiddleware
    {
        private readonly ILogger<ErrorHandling> _logger;

        public ErrorHandling(ILogger<ErrorHandling> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (DbUpdateException e)
            {
                _logger.LogError(e, e.InnerException.Message);
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(e.InnerException.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync("Something went wrong.");
            }
        }
    }
}
