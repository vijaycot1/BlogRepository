using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using UserService.ContextModel;
using MyAngular.Services;
using MyAngular.Models;
using System.Threading.Tasks;

namespace MyAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        
        // GET api/values
        [HttpPost("RegisterUser")]
        public async Task<ActionResult<string>> RegisterUser(CreateUserEntity obj)
        {

            var res = await _userService.CreateUser(obj);
            if (res) return "User Created SUccessfully";
            else return "Failed to Create User";
        }

        [HttpPost("Authenticate")]
        public async Task<ActionResult<IEnumerable<Models.Users>>> Authenticate([FromBody] Models.Authenticate model)
        {
            Users user = await _userService.Authenticate(model.UserName,model.Password);
            if (user == null)
                return BadRequest(new { message = "UserName Not Found!!!" });

            return Ok(user);
        }

    }
}