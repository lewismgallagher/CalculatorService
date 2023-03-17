

using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace CalculatorAPI.MiddleWare
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

        public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ProblemDetails problemDetails = new ProblemDetails()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "Internal Server Error",
                    Title = "Internal Server Error",
                    Detail = "An Internal Server Error Occured/n" + ex.Message
                };

                string json = JsonSerializer.Serialize(problemDetails);

                context.Response.ContentType = "application/problem+json";

                await context.Response.WriteAsJsonAsync(json);

            }
        }
    }
}
