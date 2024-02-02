﻿
using PizzeriaManagementAPI.Exceptions;

namespace PizzeriaManagementAPI.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            this._logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something Went Wrong");
            }
            catch (Exception ex) 
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(ex.Message);
            }            
        }
    }
}
