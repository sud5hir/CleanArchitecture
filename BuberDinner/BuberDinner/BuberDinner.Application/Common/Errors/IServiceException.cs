using System.Net;
namespace BuberDinner.Application.Common.Errors;

public interface IServiceException
{
    public string ErrorMessage { get; }

    public HttpStatusCode StatusCode { get; }
}