using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace AuthenticationService.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Claim[] Claims { get; set; }
        public string SecretKey { get; set; } 
    }
}
