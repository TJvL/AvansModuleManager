using ModuleManager.UserDAL.Interfaces;
using ModuleManager.UserDAL.Repositories;
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

namespace ModuleManager.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISysteemRolRepository _systeemRolRepository;

        public AccountController(ISysteemRolRepository systeemRolRepository)
        {
            _systeemRolRepository = systeemRolRepository;
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {

                if (AuthenticateUser(loginVM.UserNaam, loginVM.Wachtwoord))
                {
                    // Create the authentication cookie and redirect the user to welcome page
                    FormsAuthentication.RedirectFromLoginPage(loginVM.UserNaam, loginVM.Remember);
                    //FormsAuthentication.SetAuthCookie()
                    String role = GetRole(loginVM.UserNaam);

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                            1, // Ticket version
                            loginVM.UserNaam, // Username associated with ticket
                            DateTime.Now, // Date/time issued
                            DateTime.Now.AddMinutes(30), // Date/time to expire
                            true, // "true" for a persistent user cookie
                            role, // User-data, in this case the roles
                            FormsAuthentication.FormsCookiePath);

                    // Encrypt the cookie using the machine key for secure transport
                    string hash = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(
                       FormsAuthentication.FormsCookieName, // Name of auth cookie
                       hash); // Hashed ticket
                    FormsAuthentication.SetAuthCookie(loginVM.UserNaam, loginVM.Remember);

                    // Set the cookie's expiration time to the tickets expiration time
                    if (ticket.IsPersistent)
                    {
                        cookie.Expires = ticket.Expiration;
                    }

                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "Home");
                   
                }
                else
                {
                    ViewBag.LoginError = "Invalid UserName and/or password";
                }
            }
            return View(loginVM);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            RegistrationVM registrationVM = new RegistrationVM();
            registrationVM.SysteemRollen = _systeemRolRepository.GetAll();

            return View(registrationVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(RegistrationVM registrationVM)
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
                        return RedirectToAction("Index", "Home");
                       
                    }
                }
            }
            registrationVM.SysteemRollen = _systeemRolRepository.GetAll();

            return View(registrationVM);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private bool AuthenticateUser(String username, String password)
        {
            string CS = ConfigurationManager.ConnectionStrings["UserSQLconnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spAuthenticateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                string encryptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
                SqlParameter paramUsername = new SqlParameter("@UserName", username);
                SqlParameter paramPassword = new SqlParameter("@Password", encryptedPassword);

                cmd.Parameters.Add(paramUsername);
                cmd.Parameters.Add(paramPassword);

                con.Open();
                int ReturnCode = (int)cmd.ExecuteScalar();
                return ReturnCode == 1;

            }
        }

        public String GetRole(String username)
        {
            String role = "Guest";
            string CS = ConfigurationManager.ConnectionStrings["UserSQLconnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select SysteemRol From [User] Where UserNaam ='" + username + "'", con);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    role = rdr[0].ToString();                  
                }

            }
            return role;
        }

    }
}