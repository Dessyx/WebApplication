using Microsoft.AspNetCore.Mvc;
using WebApplicationLesson1.Models;

namespace WebApplicationLesson1.Controllers
{
    public class ArtFormController : Controller
    {
        public ProductTable artwork = new ProductTable();



        public ActionResult ArtForm(ProductTable p)  //connected to about page - sign up must be on another page not about 
        {
            var result = artwork.insert_product(p);
            return RedirectToAction("Privacy", "Home");
        }

        [HttpGet]
        public ActionResult ArtForm()
        {
            return View(artwork);  //directs back to privacy page 
        }


    }
}
