using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.UserDAL.Interfaces
{
    public interface IUserRepository
    {
        User GetOne(string key);

        IEnumerable<User> GetAll();

        bool Create(User entity);

        bool Edit(User entity);
    }
}
