using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CapitalPlacementAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login user)
        {
            if (user is null)
            {
                return BadRequest("Invalid user request!!!");
            }
            if (user.UserName == GlobalModels.LoginUserName && user.Password == GlobalModels.LoginPassword)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(GlobalModels.JWTSecret));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(issuer: GlobalModels.JWTValidIssuer, audience: GlobalModels.JWTValidAudience, claims: new List<Claim>(), expires: DateTime.Now.AddDays(1), signingCredentials: signinCredentials);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new JWTTokenResponse
                {
                    Token = tokenString
                });
            }
            return Unauthorized();
        }
    }

    public class Login
    {
        public string? UserName
        {
            get;
            set;
        }
        public string? Password
        {
            get;
            set;
        }
    }

    public class JWTTokenResponse
    {
        public string? Token
        {
            get;
            set;
        }
    }
}
