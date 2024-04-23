namespace CookBook.Service.AuthAPI.Controllers
{
    using CookBook.Service.AuthAPI.DTOs;
    using CookBook.Service.AuthAPI.Service.Contracts;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> Login([FromBody]LoginDto login)
        {            
            var responce = await _authService.Login(login);
            if (!responce.IsSuccess)
            {
                return BadRequest(responce.Errors);
            }
            return Ok(responce.Data);
        }

        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> Register([FromBody]RegisterDto registerDto)
        {
            var responce = await _authService.Register(registerDto);

            if (!responce.IsSuccess)
            {
                return BadRequest(responce.Errors);
            }

            return Ok();
        }
    }
}
