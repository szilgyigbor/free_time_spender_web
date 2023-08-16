using FreeTimeSpenderWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FreeTimeSpenderWeb.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;


namespace FreeTimeSpenderWeb.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly IUserService _userService;


        public UserApiController(IUserService userService)
        {
            _userService = userService;
        }


        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserData loginData)
        {
            if (await _userService.UserIsRegistered(loginData))
            {
                // Creating the security context
                var claims = await _userService.CreateClaims(loginData);
                var expiresAt = DateTime.UtcNow.AddHours(1);
                
                return Ok(new
                {
                    access_token = CreateToken(claims, expiresAt),
                    expires_at = expiresAt,
                    username = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value,
                    email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value
                });
            }

            ModelState.AddModelError("Unauthorized", "You are not authorized to access the endpoint.");
            return Unauthorized(ModelState);
        }


        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] UserData signUpData)
        {

            if (await _userService.RegistrationIsValid(signUpData))
            {
                await _userService.RegisterUser(signUpData);
                
                var claims = await _userService.CreateClaims(signUpData);
                var expiresAt = DateTime.UtcNow.AddHours(1);

                return Ok(new
                {
                    access_token = CreateToken(claims, expiresAt),
                    expires_at = expiresAt,
                    username = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value,
                    email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value
                });
            }

            return Conflict();
        }


        private string CreateToken(IEnumerable<Claim> claims, DateTime expiresAt)
        {
            var secretKey = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("FreeTimeSpenderSecretKey"));

            var jwt = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expiresAt,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature
                )
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

    }
}
