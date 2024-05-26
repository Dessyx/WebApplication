using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationLesson1.Models;

namespace WebApplicationLesson1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor; // Initialize IHttpContextAccessor
        }

        public IActionResult Index(int userID, string userType)
        {
           // int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("userID");
            ViewBag.UserType = userType;
            ViewBag.UserID = userID;
            return View(new TransactionTable());
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ContactUs()  //Make another page
        {
            return View();
        }

 

        public IActionResult SignUp()  //Make another page
        {
            return View();
        }

        public IActionResult Login()  //Make another page
        {
            return View();
        }


        public IActionResult ArtForm()  //Make another page
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
