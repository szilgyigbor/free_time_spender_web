﻿using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FreeTimeSpenderWeb.Data;
using FreeTimeSpenderWeb.Models;
using FreeTimeSpenderWeb.Services.Interfaces;


namespace FreeTimeSpenderWeb.Services
{
    public class UserService : IUserService
    {
        private readonly FreeTimeSpenderContext _context;
        private PasswordHasher<UserDataModel> PasswordHasher { get; }


        public UserService(FreeTimeSpenderContext context)
        {
            _context = context;
            PasswordHasher = new PasswordHasher<UserDataModel>();
        }


        public async Task RegisterUser(UserDataModel registerData)
        {
            if (await RegistrationIsValid(registerData) is false)
            {
                throw new ArgumentException("Registration data is invalid.", nameof(registerData));
            }

            var user = new UserDataModel()
            {
                Email = registerData.Email,
                Username = registerData.Email,
                
            };

            user.Password = PasswordHasher.HashPassword(user, registerData.Password);


            await _context.SignUpDatas.AddAsync(user);
            await _context.SaveChangesAsync();

        }
        

        public async Task<ClaimsPrincipal> LoginUser(UserDataModel loginData)
        {
            var claims = await CreateClaims(loginData);
            var identity = new ClaimsIdentity(claims, "LoginCookieAuth");

            return new ClaimsPrincipal(identity);
        }


        public async Task<IEnumerable<Claim>> CreateClaims(UserDataModel userData)
        {
            if (!await UserIsRegistered(userData))
            {
                throw new ArgumentException("Credential contains invalid information.", nameof(userData));
            }
            var user = await GetUserByUsername(userData.Username);

            var claims = new List<Claim>
            {
                new (ClaimTypes.Name, user.Username),
                new (ClaimTypes.Email, user.Email),
                new ("UserId", user.Id.ToString()),
            };

            return claims;
        }


        public async Task<bool> UserIsRegistered(UserDataModel userData)
        {
            var user = await GetUserByUsername(userData.Username);
            if (user == null)
            {
                return false;
            }

            var result = PasswordHasher.VerifyHashedPassword(user, user.Password, userData.Password);
            return result == PasswordVerificationResult.Success;
        }


        public async Task<bool> RegistrationIsValid(UserDataModel userData)
        {
            var user = await GetUserByUsername(userData.Username);
            if (user != null)
            {
                return false;
            }

            user = await GetUserByEmail(userData.Email);
            if (user != null)
            {
                return false;
            }

            return true;
        }


        public async Task<UserDataModel?> GetUserById(int Id)
        {
            return await _context.SignUpDatas.FirstOrDefaultAsync(user => user.Id == Id);
        }


        private async Task<UserDataModel?> GetUserByUsername(string username)
        {
            return await _context.SignUpDatas.FirstOrDefaultAsync(user => user.Username == username);
        }


        private async Task<UserDataModel?> GetUserByEmail(string email)
        {
            return await _context.SignUpDatas.FirstOrDefaultAsync(user => user.Email == email);
        }
    }
}
