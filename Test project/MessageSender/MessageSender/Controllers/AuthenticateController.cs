using Microsoft.AspNetCore.Mvc;
using AuthenticationService;
using AuthenticationService.Models;
using System;
using System.Threading.Tasks;
using System.Security.Claims;
using AuthenticationService.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

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
            model.Claims = new Claim[]
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
