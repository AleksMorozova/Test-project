using Consumer.Models;
using Consumer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consumer.Services
{
    class UserService
    {
        private UserRepository _repository;
        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public void CreateUser(string userName) {
            _repository.Create(userName);
        }

        public List<User> GetAllUser() {
            return _repository.ReadAll();
        }
    }
}
