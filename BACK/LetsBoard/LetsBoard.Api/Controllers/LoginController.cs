using LetsAuth.Domain.Services;
using LetsAuth.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LetsAuthApi.Controllers
{
    [Route("{controller}")]
    public class LoginController : ControllerBase
    {
        private IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AuthenticateRequest model)
        {
            var response = await _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Usuário ou senha incorreta" });

            return Ok(response);
        }
    }
}
