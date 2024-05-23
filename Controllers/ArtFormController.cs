using Microsoft.AspNetCore.Mvc;
using WebApplicationLesson1.Models;

namespace WebApplicationLesson1.Controllers
{
    public class ArtFormController : Controller
    {
        public ProductTable artwork = new ProductTable();



        public ActionResult ArtForm(int userID,string userType, ProductTable p)  
        {
            var result = artwork.insert_product(p);
            return RedirectToAction("MyWork", "MyWork");
        }

        [HttpGet]
        public ActionResult ArtForm(int userID, string userType)
        {
            ViewBag.UserType = userType;
            ViewBag.UserID = userID;
            return View(new TransactionTable());  
        }


    }
}
