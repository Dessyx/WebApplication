using Microsoft.AspNetCore.Mvc;

namespace WebApplicationLesson1.Models
{
    public class UserTable : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
