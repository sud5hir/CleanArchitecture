

using BuberDinner.Application.Common.interfaces.Services;
using BuberDinner.Domain;

namespace BuberDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _usrs = new();
    public void Add(User user)
    {
        _usrs.Add(user);
    }

    public User? GetUserByEmail(string Email)
    {
        return _usrs.Find(x => x.Email == Email);
    }
}
