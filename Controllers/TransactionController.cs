using Microsoft.AspNetCore.Mvc;
using WebApplicationLesson1.Models;
using System.Data.SqlClient;

namespace WebApplicationLesson1.Controllers
{
    public class TransactionController : Controller
    {
   
        public TransactionTable tTable = new TransactionTable();
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TransactionController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor; // Initialize IHttpContextAccessor
        }


        [HttpPost]
        public ActionResult MyWork(int userID, int productID)
        {
            int? user = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");
            var result = tTable.PlaceOrder(user.GetValueOrDefault(), productID);
           /* var result2 = tTable.GetPastOrders(userID); *//*+*/

            return RedirectToAction("Details", "MyWork");
        }

        [HttpGet]
        public ActionResult MyWork()
        {
            return View(tTable);
        }
       

    }

}

