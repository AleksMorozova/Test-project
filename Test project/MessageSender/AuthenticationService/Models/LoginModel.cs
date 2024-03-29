﻿using System.Security.Claims;

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
