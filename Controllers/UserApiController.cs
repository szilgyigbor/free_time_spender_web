using FreeTimeSpenderWeb.Services;
using Microsoft.AspNetCore.Mvc;
using FreeTimeSpenderWeb.Models;

namespace FreeTimeSpenderWeb.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        [Route("signup")]
        [HttpPost]
        public async Task<UserDataModel> SignUp([FromBody] UserDataModel signUpData)
        {
            UserDataModel LoginDataModel = signUpData;
            return LoginDataModel;
        }
    }
}
