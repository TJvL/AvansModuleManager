using ModuleManager.DomainDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.UserDAL.Repositories
{
    public class UserRepository : IGenericRepository<User>
    {
        private UserContext _userContext;
        public UserRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public IEnumerable<User> GetAll()
        {
            return _userContext.User.ToList();
        }

        public User GetOne(string key)
        {
            var result = (from u in _userContext.User where u.UserNaam == key select u).FirstOrDefault();
            return result;
        }

        public bool Create(User entity)
        {
            if (entity != null)
            {
                _userContext.User.Add(entity);
                _userContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(User entity)
        {
            if (entity != null)
            {
                _userContext.User.Remove(entity);
                _userContext.SaveChanges();
                return true;
            }
            return false;
           
        }

        public bool Edit(User entity)
        {
            if (entity != null)
            {
                _userContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                _userContext.SaveChanges();
                return true;
            }
            return false;
            
        }
    }
}
