using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebApiTest.Services;

public class TokenService
{
    public string GenerateToken()
    {

        /* Initialize a new instance of the class
        designed to create and validate Json Web Tokens*/
        var tokenHandler = new JwtSecurityTokenHandler();

        // Given a string generates a byte array key
        var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);

        /* Initialize a new instance of the class
         designed for all attributes related to the issued token.*/
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new(ClaimTypes.Name,"bruce wayne"), //User.Identity.Name
                    new(ClaimTypes.Role,"admin"),       //User.Identity.Role
                    new(ClaimTypes.Role,"author")       //User.Identity.Role

            }),

            Expires = DateTime.UtcNow.AddHours(8),

            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            )

        };

        // Create a token given a tokendescriptor
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}