using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Mono.TextTemplating;
using System.ComponentModel.DataAnnotations;
using WebApplicationLesson1.Models;
using static System.Net.WebRequestMethods;

namespace WebApplicationLesson1.Controllers
{
    public class LoginController : Controller
    {

        public string errorHeading;
        public string errorMessage;
        public bool isValidLogin;
        public bool loggedIn;
        public UserTable uTable = new UserTable();
        
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string username, string userPassword)
        {


            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(userPassword))
            {
                errorHeading = "A field is empty!";
                errorMessage = "Please enter your username and password.";
                  
                return RedirectToAction("Login", "Login");
            }

            isValidLogin = uTable.Login(username, userPassword);
            string userType = uTable.GetUserType(username, userPassword);
            int userID = uTable.SelectUser(username, userPassword);
            HttpContext.Session.SetInt32("UserID", userID);

            if (isValidLogin)
            {
                if(userType == "admin")
                {
                    HttpContext.Session.SetString("LoggedIn", "true");  // Line used from Microsoft, 2024
                    return RedirectToAction("ArtForm", "ArtForm", new { userID = userID, userType = userType });
                }
                else
                {
                    HttpContext.Session.SetString("LoggedIn", "true"); // Line used from Microsoft, 2024
                    return RedirectToAction("Index", "Home", new { userID = userID, userType = userType });
                }
               
            }
            else
            {
                HttpContext.Session.SetString("LoggedIn", "false"); // Line used from Microsoft, 2024
                errorHeading = "Incorrect Credentials!";
                errorMessage = "Please enter your username and password.";
                return RedirectToAction("Login", "Login");
            }
        }


    }

    //          REFERENCES
   /* Microsoft, 2024. Session and state management in ASP.NET Core. [Online]
Available at: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-8.0
[Accessed 27 May 2024].*/
}
