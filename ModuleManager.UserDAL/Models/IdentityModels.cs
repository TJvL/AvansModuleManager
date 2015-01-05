using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ModuleManager.UserDAL.Models
{

    //public class ApplicationUser : IdentityUser
    //{
    //    [Required]
    //    public string FirstName { get; set; }

    //    [Required]
    //    public string LastName { get; set; }

    //    [Required]
    //    public string Email { get; set; }
    //}


    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    //{
    //    public ApplicationDbContext()
    //        : base("DefaultConnection")
    //    {

    //    }
    //}


    public class IdentityManager
    {
        public bool RoleExists(string name)
        {
            var rm = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new UserContext()));
            return rm.RoleExists(name);
        }


        public bool CreateRole(string name)
        {
            var rm = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new UserContext()));
            var idResult = rm.Create(new IdentityRole(name));
            return idResult.Succeeded;
        }


        public bool CreateUser(User user, string password)
        {
            var um = new UserManager<User>(
                new UserStore<User>(new UserContext()));
            var idResult = um.Create(user, password);
            return idResult.Succeeded;
        }


        public bool AddUserToRole(string userNaam, string roleName)
        {
            var um = new UserManager<User>(
                new UserStore<User>(new UserContext()));
            var idResult = um.AddToRole(userNaam, roleName);
            return idResult.Succeeded;
        }


        public void ClearUserRoles(string userNaam)
        {
            var um = new UserManager<User>(
                new UserStore<User>(new UserContext()));
            var user = um.FindById(userNaam);
            var currentRoles = new List<IdentityUserRole>();
            currentRoles.AddRange(user.Roles);
            foreach (var role in currentRoles)
            {
                um.RemoveFromRole(userNaam, role.RoleId);//RoleId instead of RoleName
            }
        }
    }
}
