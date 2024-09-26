using HR_Management.Application.Contracts.Identity;
using HR_Management.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAuthService authService;

        public AccountController(IAuthService authService)
        {
            this.authService = authService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            var response=await authService.Login(request);
            return Ok(response);
        }
        [HttpPost("register")]
        public async Task<ActionResult<RegisterationResponse>> Register(RegisterationRequest request) { 
            var response=await authService.Register(request);
            return Ok(response);
        }
    }
}
