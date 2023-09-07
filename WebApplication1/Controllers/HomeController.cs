using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        MyExamDBEntities db = new MyExamDBEntities();
        List<StockInfoTB> stockList;
        public HomeController() 
        { 
            stockList = db.StockInfoTBs.ToList();
        }
        // GET: Home
        public ActionResult Index()
        { 
            return View("Index", stockList);
        }
    }
}