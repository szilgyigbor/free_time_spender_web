﻿using FreeTimeSpenderWeb.Services;
using Microsoft.AspNetCore.Mvc;
using FreeTimeSpenderWeb.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;


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
        public async Task<IActionResult> SignUp([FromBody] UserDataModel signUpData)
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
