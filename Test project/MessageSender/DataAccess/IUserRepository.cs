using DomainModel;
using System.Collections.Generic;

namespace DataAccess
{
    public interface IUserRepository
    {
        void Create(string userName);
        List<User> ReadAll();
    }
}
