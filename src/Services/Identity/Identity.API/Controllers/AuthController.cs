using Identity.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        public AuthController(UserManager<ApplicationUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel req)
        {
            var user = new ApplicationUser { UserName = req.UserName, Email = req.Email };
            var res = await _userManager.CreateAsync(user, req.Password);
            if (!res.Succeeded)
                return BadRequest(res.Errors);
            return Ok();

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return Unauthorized();

            var token = await _tokenService.CreateToken(user, model.RememberMe);
            return Ok(new { token });
        }

    }
}
