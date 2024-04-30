using Microsoft.AspNetCore.Mvc;
using WebApplicationLesson1.Models;

namespace WebApplicationLesson1.Controllers
{
    public class UserController : Controller
    {
        public UserTable uTable = new UserTable();

        public ActionResult SignUp(UserTable user)  
        {
            var result = uTable.insert_User(user);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View(uTable); 
        }


    }
}
