using System.Net;
using BuberDinner.Domain;

namespace BuberDinner.Application.Common.Errors;
public class DuplicateEmail : Exception, IServiceException
{
    string
   IServiceException.ErrorMessage => "email already exists";

    HttpStatusCode
   IServiceException.StatusCode => HttpStatusCode.Conflict;
}