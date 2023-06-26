using ProductManagement.DB;
using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginDTO obj) {
            DemoSumm23_AEntities db = new DemoSumm23_AEntities();
            var user = (from u in db.Users
                       where u.Username.Equals(obj.Username) &&
                       u.Password.Equals(obj.Password)
                       select u).SingleOrDefault();
            if (user != null) {
                Session["user"] = user.Username;
                Session["type"] = user.Type;
                return RedirectToAction("Index", "Order");
            }
            ViewBag.Msg = "Username password invalid";
            return View();



        }
        public ActionResult SignUp() {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}