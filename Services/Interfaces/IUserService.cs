using System.Security.Claims;
using FreeTimeSpenderWeb.Models;

namespace FreeTimeSpenderWeb.Services.Interfaces
{
    public interface IUserService
    {
        Task RegisterUser(UserDataModel registerData);
        Task<ClaimsPrincipal> LoginUser(UserDataModel loginData);
        Task<IEnumerable<Claim>> CreateClaims(UserDataModel userData);
        Task<bool> UserIsRegistered(UserDataModel userData);
        Task<bool> RegistrationIsValid(UserDataModel userData);
    }
}
