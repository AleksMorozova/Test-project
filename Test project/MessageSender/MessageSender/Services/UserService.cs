using DataAccess;
using DataAccess.Repositories;
using DomainModel;
using MessageSender.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace MessageSender.Controllers
{
    public class UserService
    {
        private MessageService _messageService;
        IUserRepository _userRepository;
        ILogger<UserController> _logger;

        public UserService(MessageService messageService,
                           IUserRepository userRepository,
                           ILogger<UserController> logger)
        {
            _messageService = messageService;
            _userRepository = userRepository;
            _logger = logger;

        }

        public void AddUser(string userName)
        {
            _logger.LogInformation("Add user with name {0}", userName);

            _messageService.SendMessage(userName);
        }

        public List<User> GetAllUser()
        {
            _logger.LogInformation("Load all user");

            return _userRepository.ReadAll();
        }
    }
}
