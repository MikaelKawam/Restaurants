﻿using Restaurants.Domain.Exceptions;

namespace Restaurants.API.Middlewares
{
    public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException ex)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(ex.Message);
                
                logger.LogWarning(ex, ex.Message);
            }
            //catch (ValidationException ex)
            //{
            //    logger.LogWarning(ex, ex.Message);
            //    context.Response.StatusCode = 400;
            //    await context.Response.WriteAsync(ex.Message);
            //}
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                await context.Response.WriteAsync("Something went wrong");
            }
        }
    }
}
