using DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IUserRepository
    {
        void Create(string userName);
        List<User> ReadAll();
    }
}
