using ModuleManager.UserDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.UserDAL.Repositories
{
    public class SysteemRolRepository
    {
        private UserContext _userContext;

        public SysteemRolRepository()
        {
            _userContext =  new UserContext();
        }

        public IEnumerable<SysteemRol> GetAll()
        {
            return _userContext.SysteemRol;
        }

    }
}
