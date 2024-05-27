using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using WebApplicationLesson1.Models;


namespace WebApplicationLesson1.Controllers
{
    public class MyWorkController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MyWorkController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor; // Initialize IHttpContextAccessor
        }

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
            int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");
            ViewBag.UserID = userID.GetValueOrDefault();
            return View(new TransactionTable());
        }

    }
}
