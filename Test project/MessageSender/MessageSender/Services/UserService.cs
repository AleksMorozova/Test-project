using DataAccess;
using DataAccess.Repositories;
using DomainModel;
using MessageSender.Services;
using System.Collections.Generic;

namespace MessageSender.Controllers
{
    public class UserService
    {
        private MessageService _messageService;
        IUserRepository _userRepository;
        public UserService(MessageService messageService, IUserRepository userRepository)
        {
            _messageService = messageService;
            _userRepository = userRepository;
        }

        public void AddUser(string userName)
        {
            _messageService.SendMessage(userName);
        }

        public List<User> GetAllUser()
        {
            return _userRepository.ReadAll();
        }
    }
}
