using Microsoft.AspNetCore.Mvc;
using AuthenticationService.Models;
using System.Security.Claims;
using AuthenticationService.Services;

namespace MessageSender.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly JwtService _jwtService;

        public AuthenticateController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            model.Claims = new[]
            {
                new Claim(ClaimTypes.Name, model.Username),
            };

            return Ok(new
            {
                token = _jwtService.GenerateToken(model)
            });
        }
    }
}
