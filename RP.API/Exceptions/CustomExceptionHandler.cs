using System.Text.RegularExpressions;
using RP.Library.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;

namespace RP.API.Exceptions
{
    public class CustomExceptionHandler : IExceptionHandler
    {
        private readonly Dictionary<Type, Func<HttpContext, Exception, Task>> _exceptionHandlers;
        private readonly ILogger<CustomExceptionHandler> logger;
        public CustomExceptionHandler(ILogger<CustomExceptionHandler> logger)
        {
            // Register known exception types and handlers.
            _exceptionHandlers = new()
            {
                { typeof(ValidationException), HandleValidationException },
                { typeof(NotFoundException), HandleNotFoundException },
                {typeof(JWTException), HandleJwtException },
            };
            this.logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            Log.Logger.Error(exception, exception.Message);
            logger.LogError(exception, exception.Message);
            var exceptionType = exception.GetType();

            if (_exceptionHandlers.ContainsKey(exceptionType))
            {
                await _exceptionHandlers[exceptionType].Invoke(httpContext, exception);
                return true;
            }

            if (exceptionType == typeof(System.Exception))
            {
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                await httpContext.Response.WriteAsJsonAsync(new
                {
                    Code = StatusCodes.Status400BadRequest,
                    Message = exception.Message
                });
                return true;
            }

            return false;
        }

        private async Task HandleValidationException(HttpContext httpContext, Exception ex)
        {
            Log.Logger.Error(ex, ex.Message);
            logger.LogError(ex, ex.Message);
            var exception = (ValidationException)ex;
            logger.LogError("Error Message: {exceptionMessage}, Time of occurrence {time}", exception.Message, DateTime.UtcNow);
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            await httpContext.Response.WriteAsJsonAsync(new
            {
                Code = StatusCodes.Status400BadRequest,
                Message = Regex.Replace(exception.Errors.First().Value.First(), "'", "")
            });
        }

        private async Task HandleNotFoundException(HttpContext httpContext, Exception ex)
        {
            Log.Logger.Error(ex, ex.Message);
            logger.LogError(ex, ex.Message);
            var exception = (NotFoundException)ex;

            httpContext.Response.StatusCode = StatusCodes.Status404NotFound;

            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails()
            {
                Status = StatusCodes.Status404NotFound,
                Title = "The specified resource was not found.",
                Detail = exception.Message
            });
        }

        private async Task HandleJwtException(HttpContext httpContext, Exception ex)
        {
            Log.Logger.Error(ex, ex.Message);
            logger.LogError(ex, ex.Message);
            var exception = ex as JWTException;
            httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;

            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails()
            {
                Status = StatusCodes.Status401Unauthorized,
                Title = "Unauthorized access.",
                Detail = exception?.Message ?? ex.Message
            });
        }
      
    }

}
