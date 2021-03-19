using DataAccess;
using DataAccess.Repositories;
using Microsoft.Extensions.Logging;

namespace Consumer.Services
{
    class UserService
    {
        private IUserRepository _repository;
        ILogger<UserService> _logger;

        public UserService(IUserRepository repository, ILogger<UserService> logger)
        {
            _repository = repository;
            _logger = logger;

        }

        public void CreateUser(string userName) {
            _logger.LogInformation("Create User");

            _repository.Create(userName);
        }
    }
}
