using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using WebApplicationLesson1.Models;

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
                    HttpContext.Session.SetString("LoggedIn", "true");
                    return RedirectToAction("ArtForm", "ArtForm", new { userID = userID, userType = userType });
                }
                else
                {
                    HttpContext.Session.SetString("LoggedIn", "true");
                    return RedirectToAction("Index", "Home", new { userID = userID, userType = userType });
                }
               
            }
            else
            {
                HttpContext.Session.SetString("LoggedIn", "false");
                errorHeading = "Incorrect Credentials!";
                errorMessage = "Please enter your username and password.";
                return RedirectToAction("Login", "Login");

            }
        }


    }


}
