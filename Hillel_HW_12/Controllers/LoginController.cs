using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hillel_HW_12
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly string secret;
        private readonly string myIssuer;
        private readonly string myAudience;
        public LoginController(IConfiguration configuration)
        {
            secret = configuration.GetValue<string>("Auth:Secret")!;
            myIssuer = configuration.GetValue<string>("Auth:Issuer")!;
            myAudience = configuration.GetValue<string>("Auth:Audience")!;
        }

        [HttpPost]
        public string GenerateToken([FromBody] LoginModel request)
        {
            //https://dotnetcoretutorials.com/creating-and-validating-jwt-tokens-in-asp-net-core/?expand_article=1

            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));

            //var myIssuer = "http://mysite.com";
            //var myAudience = "http://myaudience.com";

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, request.Login),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = myIssuer,
                Audience = myAudience,
                SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [HttpGet]
        public bool VerifyToken(string token)
        {
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));

            //var myIssuer = "http://mysite.com";
            //var myAudience = "http://myaudience.com";

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = myIssuer,
                    ValidAudience = myAudience,
                    IssuerSigningKey = mySecurityKey
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
