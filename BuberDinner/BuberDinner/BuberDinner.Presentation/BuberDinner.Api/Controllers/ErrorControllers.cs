using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using BuberDinner.Application.Common.Errors;

namespace BuberDinner.Presentation.BuberDinner.Api.Controllers;

[ApiController]
public class ErrorControllers : ControllerBase
{
    [Route("error")]
    public string Error()
    {
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
        // var (statusCode, message) = exeception switch
        // {
        //     IServiceException => (statusCode.HttpStatusCode.)
        // };
        var exception = context.Error; // Your exception
        var code = 500; // Internal Server Error by default

        // if (exception is MyNotFoundException) code = 404; // Not Found
        // else if (exception is MyUnauthException) code = 401; // Unauthorized
        // else if (exception is MyException) code = 400; // Bad Request

        Response.StatusCode = code; // You can use HttpStatusCode enum instead

        return exception.ToString() + "Sudhir"; // Your error model
    }
}