using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Helpers.CustomException;

namespace BuberDinner.Presentation.BuberDinner.Api.Middleware;
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    //  private readonly ILoggerManager _logger;
    public ExceptionMiddleware(RequestDelegate next)
    {
        //  _logger = logger;
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            switch (error)
            {
                case AppException e:
                    // custom application error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;

                    break;
                case KeyNotFoundException e:
                    // not found error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    // unhandled error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(new { message = error?.Message });
            await response.WriteAsync(result);
        }
    }
}
