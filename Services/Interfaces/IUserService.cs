using System.Security.Claims;
using FreeTimeSpenderWeb.Models;

namespace FreeTimeSpenderWeb.Services.Interfaces
{
    public interface IUserService
    {
        Task RegisterUser(UserData registerData);
        Task<ClaimsPrincipal> LoginUser(UserData loginData);
        Task<IEnumerable<Claim>> CreateClaims(UserData userData);
        Task<bool> UserIsRegistered(UserData userData);
        Task<bool> RegistrationIsValid(UserData userData);
    }
}
