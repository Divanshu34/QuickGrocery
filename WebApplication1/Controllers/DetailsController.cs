using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DetailsController : Controller
    {
        MyExamDBEntities db = new MyExamDBEntities();
        List<StockInfoTB> stockList;
        public DetailsController()
        {
            stockList = db.StockInfoTBs.ToList();
        }
        // GET: Details
        public ActionResult Details(int? id)
        {
            StockInfoTB stockInfo = (from st in  db.StockInfoTBs
                                     where st.ItemId == id
                                     select st).First();

            return View("Details", stockInfo);
        }
    }
}