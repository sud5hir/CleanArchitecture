using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuberDinner.Application.Authentication.Common
{
    public record AuthenticationResult
   (Guid Id,
   string FirstName, string LastName, string Email, string Token);

}