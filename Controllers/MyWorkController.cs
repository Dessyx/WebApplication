using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using WebApplicationLesson1.Models;


namespace WebApplicationLesson1.Controllers
{
    public class MyWorkController : Controller
    {

        Products product = new Products();
        UserTable user = new UserTable();
        public IActionResult MyWork(int userID, string userType)
        {
            product.FetchData();
            List<string> productNames = product.PopulateDropDown();
            ViewBag.UserType = userType; 
            ViewBag.UserID = userID; 

            return View(product);
        }       

        public IActionResult Details()
        {

            return View();
        }

    }
}
