using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CSS.Domains.Entities;
using Microsoft.IdentityModel.Tokens;

namespace CSS.Application.Utilities.TokenUtilities;
public static class TokenGenerator
{
    public static string GenerateToken(this User user, JwtOptions options)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(options.Secret);
        var claimsList = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Sub, user.EntityId.ToString()),
                new Claim(ClaimTypes.Role, user.Role.RoleName)
            };
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Audience = options.Audience,
            Issuer = options.Issuer,
            Subject = new ClaimsIdentity(claimsList),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}