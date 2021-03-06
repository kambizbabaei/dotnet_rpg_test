using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pr.dto.User;
using pr.Models;
using pr.services.Auth;

namespace pr.Controller
{

    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        public readonly IAuthService AuthService;
        public AuthController(IAuthService AuthService)
        {
            this.AuthService = AuthService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterLoginDto request)
        {
            ServiceResponse<int> response = await AuthService.Register(
                new User { username = request.Username }, request.Password);
            if (response.isSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> login(UserRegisterLoginDto request)
        {
            ServiceResponse<string> response = await AuthService.Login(request.Username, request.Password);
            if (response.isSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

    }
}