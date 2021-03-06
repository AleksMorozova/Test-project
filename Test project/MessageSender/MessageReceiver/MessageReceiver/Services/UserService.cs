using DataAccess;
using DataAccess.Repositories;

namespace Consumer.Services
{
    class UserService
    {
        private IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public void CreateUser(string userName) {
            _repository.Create(userName);
        }
    }
}
