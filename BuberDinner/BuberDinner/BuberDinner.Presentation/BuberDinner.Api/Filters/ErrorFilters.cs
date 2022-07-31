using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BuberDinner.Presentation.BuberDinner.Api.Filters;
public class ErrorFilters : IExceptionFilter
{
    private readonly IHostEnvironment _hostEnvironment;

    public ErrorFilters(IHostEnvironment hostEnvironment) =>
        _hostEnvironment = hostEnvironment;

    public void OnException(ExceptionContext context)
    {
        // if (!_hostEnvironment.IsDevelopment())
        // {
        //     // Don't display exception details unless running in Development.
        //     return;
        // }

        context.Result = new ContentResult
        {
            Content = context.Exception.ToString() + "Sudhir"
        };

        context.ExceptionHandled = true;

    }
}