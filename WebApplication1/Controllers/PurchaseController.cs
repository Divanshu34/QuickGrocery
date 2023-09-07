using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class PurchaseController : Controller
    {
        MyExamDBEntities db = new MyExamDBEntities();
        List<StockInfoTB> stockList;
        List<OrderDetailsTB> orderList;
        public PurchaseController()
        {
            stockList = db.StockInfoTBs.ToList();
            orderList = db.OrderDetailsTBs.ToList();
        }
        [HttpPost]
        public ActionResult Purchase(int? id, Stocks stocks)
        {
            int purQty = stocks.PurchaseQuantity;
            var stockInfo = (from st in db.StockInfoTBs
                             where st.ItemId == id
                             select st).First();
            if (stockInfo.Available_Quantity < purQty)
            {
                
                ViewBag.message = "Available Quatity is less";
                return View("~/Views/Details/Details.cshtml", stockInfo);
            }
            else
            {
                stockInfo.Available_Quantity = Convert.ToInt32(stockInfo.Available_Quantity) - purQty;

                OrderDetailsTB orderInfo = new OrderDetailsTB()
                {
                    ItemId = id,
                    Purchase_Quantity = purQty,
                    ODate = DateTime.Now
                };

                db.OrderDetailsTBs.Add(orderInfo);

                db.SaveChanges();
                return Redirect("/Home/Index");
            }
            

        8}
    }

    public class Stocks
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string company { get; set; }
        public int Available_Quantity { get; set; }
        public int Prize { get; set; }
        public int PurchaseQuantity { get; set; }
    }
}