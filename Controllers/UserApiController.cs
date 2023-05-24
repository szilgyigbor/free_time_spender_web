using FreeTimeSpenderWeb.Sevices;
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
        public async Task<SignUpDataModel> SignUp([FromBody] SignUpDataModel signUpData)
        {
            SignUpDataModel signUpDataModel = signUpData;
            return signUpDataModel;
        }
    }
}
