using System;
using System.Collections.Generic;
using DomainModel;
using Microsoft.AspNetCore.Mvc;

namespace MessageSender.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("add")]
        public void Add(String name)
        {
            _userService.AddUser(name);
        }

        [HttpGet("all")]
        public List<User> All()
        {
            return _userService.GetAllUser();
        }
    }
}
