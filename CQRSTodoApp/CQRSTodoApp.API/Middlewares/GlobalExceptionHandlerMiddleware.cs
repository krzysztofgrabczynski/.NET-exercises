using CQRSTodoApp.Domain.Exceptions.TodoTask;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CQRSTodoApp.API.Middlewares
{
    public class GlobalExceptionHandlerMiddleware : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError($"An error occured iwht error message: {exception.Message}");

            var (httpStatus, type, detail) = exception switch
            {
                TodoTaskNotFoundException => (HttpStatusCode.NotFound, "Resource Not Found", exception.Message),
                _ => (HttpStatusCode.InternalServerError, "Internal Server Error", "An internal server error occured")
            };
                
            var problemDetails = new ProblemDetails()
            {
                Type = type,
                Detail = detail,
                Status = (int)httpStatus,
            };

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
            return true;
        }
    }
}
