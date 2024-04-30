using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using WebApplicationLesson1.Models;


namespace WebApplicationLesson1.Controllers
{
    public class MyWorkController : Controller
    {

        Products product = new Products();

        public IActionResult MyWork()
        {
            product.FetchData();
            List<string> productNames = product.PopulateDropDown();
            return View(product);
        }       

    }
}
