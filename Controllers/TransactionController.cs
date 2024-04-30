using Microsoft.AspNetCore.Mvc;
using WebApplicationLesson1.Models;
using System.Data.SqlClient;

namespace WebApplicationLesson1.Controllers
{
    public class TransactionController : Controller
    {
   
        public TransactionTable tTable = new TransactionTable();

        [HttpPost]
        public ActionResult MyWork( int userID, int productID)
        {
            var result = tTable.PlaceOrder( userID, productID);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult MyWork()
        {
            return View(tTable);
        }
       

    }

}

