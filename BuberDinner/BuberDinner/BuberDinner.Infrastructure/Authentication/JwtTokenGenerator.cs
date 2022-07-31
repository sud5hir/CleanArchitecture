
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BuberDinner.Application.Common.interfaces.Authentication;
using BuberDinner.Application.Common.interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace BuberDinner.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtToekenGenerator
{
    private readonly IDateTimeProvider _iDateTimeProvider;
    private readonly JwtSettings _JwtSettings;

    public JwtTokenGenerator(IDateTimeProvider iDateTimeProvider, IOptions<JwtSettings> JwtSettings)
    {
        _iDateTimeProvider = iDateTimeProvider;
        _JwtSettings = JwtSettings.Value;
    }

    public string GenerateToken(Guid userId, string FirstName, string LastName)
    {
        var siginingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_JwtSettings.Secret)), SecurityAlgorithms.HmacSha256);

        var claims = new[]
        { new Claim(JwtRegisteredClaimNames.UniqueName,userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName,FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName,LastName),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    };


        var securityToken = new JwtSecurityToken(
            issuer: _JwtSettings.Issuer,
            audience: _JwtSettings.Audience,
            expires: _iDateTimeProvider.UtcNow.AddMinutes(_JwtSettings.ExpiryMinutes),
            signingCredentials: siginingCredentials,
            claims: claims
                        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}