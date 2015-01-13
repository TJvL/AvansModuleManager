using System.Collections.Generic;
using System.Linq;
using ModuleManager.UserDAL;
using AutoMapper;

namespace ModuleManager.Web.ViewModels.PartialViewModel
{
    public class UserListViewModel
    {

        public ICollection<UserViewModel> Users { get; set; }

        public int RecordsFiltered { get { return Users.Count; } }

        public int RecordsTotal { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="recordsTotal">Totaal aantal users in de datasource"</param>
        public UserListViewModel(int recordsTotal)
        {
            RecordsTotal = recordsTotal;
        }

        public void AddUsers(IEnumerable<User> userList)
        {
            Users = userList
                .Select(Mapper.Map<User, UserViewModel>)
                .ToList();
            
        }
    }
}