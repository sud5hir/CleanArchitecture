using BuberDinner.Domain;

namespace BuberDinner.Application.Common.interfaces.Services;
public interface IUserRepository
{
    User? GetUserByEmail(string Email);

    void Add(User user);

}