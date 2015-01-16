<<<<<<< HEAD
﻿using ModuleManager.UserDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using ModuleManager.UserDAL.Interfaces;
>>>>>>> origin/master_development

namespace ModuleManager.UserDAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User GetOne(string key)
        {
            using (var context = new UserContext())
            {
                return context.User.Find(key);
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (var context = new UserContext())
            {
<<<<<<< HEAD
                return (from u in context.User select u).ToList();
=======
                return context.User.ToList();
>>>>>>> origin/master_development
            }
        }

        public bool Create(User entity)
        {
            using (var context = new UserContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Added;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Edit(User entity)
        {
            using (var context = new UserContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }
<<<<<<< HEAD

=======
>>>>>>> origin/master_development
    }
}
