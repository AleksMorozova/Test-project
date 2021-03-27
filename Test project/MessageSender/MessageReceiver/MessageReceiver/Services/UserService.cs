using DataAccess;
using Microsoft.Extensions.Logging;

namespace MessageReceiver.Services
{
    class UserService
    {
        private readonly IUserRepository _repository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository repository, ILogger<UserService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public void CreateUser(string userName)
        {
            _logger.LogInformation("Create User");
            _repository.Create(userName);
        }
    }
}
