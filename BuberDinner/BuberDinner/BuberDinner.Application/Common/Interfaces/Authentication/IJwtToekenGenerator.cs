namespace BuberDinner.Application.Common.interfaces.Authentication;
public interface IJwtToekenGenerator
{

    string GenerateToken(Guid userId, string FirstName, string LastName);
}