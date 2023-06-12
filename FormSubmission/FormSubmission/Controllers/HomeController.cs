using FormSubmission.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormSubmission.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Login()
        {
            //ViewBag.Name = Request["Username"];
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Username, string Password) {
            //ViewBag.Name = form["Username"];
            ViewBag.Name = Username;
            return View();
        }
        [HttpGet]
        public ActionResult SignUp() {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User u) {
            //var test = u;
            if (ModelState.IsValid) { 
                return RedirectToAction("Login");
            }
            return View();
        }
    }
}