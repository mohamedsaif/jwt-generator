using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

namespace JWT.Generator.API.Utils
{
    public class TokenGenerator
    {
        public static SecurityToken GenerateToken(string userId)
        {
            var mySecret = "asdv234234^&%&^%&^hjsdfb2%%%1234";
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));

            var myIssuer = "http://mohamedsaif.com";
            var myAudience = "http://mohamedsaifaudience.com";

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = myIssuer,
                Audience = myAudience,
                SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return token;
        }

        public static string GenerateTokenAsString(string userId)
        {
            var token = GenerateToken(userId);
            
            if (token == null)
            {
                return string.Empty;
            }

            return token.UnsafeToString();
        }

    }
}
