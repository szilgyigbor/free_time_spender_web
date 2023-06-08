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
        public async Task<LoginDataModel> SignUp([FromBody] LoginDataModel signUpData)
        {
            LoginDataModel LoginDataModel = signUpData;
            return LoginDataModel;
        }
    }
}
