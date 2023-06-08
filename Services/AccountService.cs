using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FreeTimeSpenderWeb.Data;
using FreeTimeSpenderWeb.Models;
using FreeTimeSpenderWeb.Services.Interfaces;



namespace FreeTimeSpenderWeb.Services
{
    public class AccountService
    {
        private readonly FreeTimeSpenderContext _context;
        private PasswordHasher<UserDataModel> PasswordHasher { get; }

        public AccountService(FreeTimeSpenderContext context)
        {
            _context = context;
            PasswordHasher = new PasswordHasher<UserDataModel>();
        }

        public async Task RegisterUser(UserDataModel registerData)
        {
            var user = new UserDataModel()
            {
                Email = registerData.Email,
                Username = registerData.Email,
                
            };

            user.Password = PasswordHasher.HashPassword(user, registerData.Password);


            _context.SignUpDatas.Add(user);
            await _context.SaveChangesAsync();

        }
    }
}
