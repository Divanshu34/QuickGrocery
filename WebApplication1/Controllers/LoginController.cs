using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        MyExamDBEntities db = new MyExamDBEntities();
        List<StockInfoTB> stockList;
        List<OrderDetailsTB> orderList;
        List<LoginTB> loginList;
        public LoginController()
        {
            stockList = db.StockInfoTBs.ToList();
            orderList = db.OrderDetailsTBs.ToList();
            loginList = db.LoginTBs.ToList();
        }
        // GET: Login
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(SmallUser smallUser)
        {
            var signedUser = (from su in db.LoginTBs
                             where su.EmailId == smallUser.EmailId && su.Password == smallUser.Password
                             select su).FirstOrDefault();

            if (signedUser != null)
            {
                FormsAuthentication.SetAuthCookie(signedUser.EmailId, false);
                return Redirect("/Home/Index");
            }
            else
            {
                return View();
            }
        }
    }

    public class SmallUser
    {
        public string Password { get; set; }
        public string EmailId { get; set; }
    }
}