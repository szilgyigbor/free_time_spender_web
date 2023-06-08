using FreeTimeSpenderWeb.Services;
using Microsoft.AspNetCore.Mvc;
using FreeTimeSpenderWeb.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;


namespace FreeTimeSpenderWeb.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly UserService _userService;


        public UserApiController(UserService userService)
        {
            _userService = userService;
        }


        [Route("signup")]
        [HttpPost]
        public async Task<UserDataModel> SignUp([FromBody] UserDataModel signUpData)
        {
            UserDataModel LoginDataModel = signUpData;
            return LoginDataModel;
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
