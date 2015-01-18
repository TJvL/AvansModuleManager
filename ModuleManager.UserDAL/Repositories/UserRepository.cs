﻿using System;
using System.Collections.Generic;
using System.Linq;
using ModuleManager.UserDAL.Interfaces;

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
                return context.User.ToList();
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
    }
}
