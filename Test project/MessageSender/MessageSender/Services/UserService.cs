using MessageSender.Services;

namespace MessageSender.Controllers
{
    public class UserService
    {
        private MessageService _messageService;
        public UserService(MessageService messageService)
        {
            _messageService = messageService;
        }

        public void AddUser(string userName)
        {
            _messageService.SendMessage("Add", userName);
        }

        public void GetAllUser()
        {
            _messageService.SendMessage("All");
        }
    }
}
