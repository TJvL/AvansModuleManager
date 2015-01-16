using ModuleManager.UserDAL.Interfaces;
using ModuleManager.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ModuleManager.Web.Controllers.Api
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISysteemRolRepository _systeemRolRepository;
        public UsersController(IUserRepository userRepository, ISysteemRolRepository systeemRolRepository)
        {
            _userRepository = userRepository;
            _systeemRolRepository = systeemRolRepository;
        }

        public ActionResult Create()
        {
            RegistrationVM registrationVM = new RegistrationVM();
            registrationVM.SysteemRollen = _systeemRolRepository.GetAll();
            

            return PartialView("~/Views/Admin/Users/_Add.cshtml", registrationVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "SysteemRollen")]RegistrationVM registrationVM)
        {
            
            if (ModelState.IsValid)
            {

                // Read the connection string from web.config.
                // ConfigurationManager class is in System.Configuration namespace
                string CS = ConfigurationManager.ConnectionStrings["UserSQLconnection"].ConnectionString;
                // SqlConnection is in System.Data.SqlClient namespace
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spRegisterUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter username = new SqlParameter("@UserNaam", registrationVM.UserNaam);
                    // FormsAuthentication class is in System.Web.Security namespace
                    string encryptedPassword = FormsAuthentication.
                        HashPasswordForStoringInConfigFile(registrationVM.Wachtwoord, "SHA1");
                    SqlParameter password = new SqlParameter("@Wachtwoord", encryptedPassword);
                    SqlParameter role = new SqlParameter("@SysteemRol", registrationVM.SelectedSysteemRol);
                    SqlParameter email = new SqlParameter("@email", registrationVM.Email);
                    SqlParameter name = new SqlParameter("@naam", registrationVM.Naam);

                    cmd.Parameters.Add(username);
                    cmd.Parameters.Add(password);
                    cmd.Parameters.Add(role);
                    cmd.Parameters.Add(email);
                    cmd.Parameters.Add(name);

                    con.Open();
                    int ReturnCode = (int)cmd.ExecuteScalar();
                    if (ReturnCode == -1)
                    {
                        ViewBag.UsernameError = "User Name already in use, please choose another user name";
                    }
                    else
                    {
                        string url = Url.Action("UserOverview", "Admin");
                        return Json(new { success = true, url = url });
                    }
                }
            }

            registrationVM.SysteemRollen = _systeemRolRepository.GetAll();
            return PartialView("~/Views/Admin/Users/_Add.cshtml", registrationVM);                 
        }




    }
}