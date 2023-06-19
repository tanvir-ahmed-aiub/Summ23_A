using FormSubmission.DB;
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
        public ActionResult Index() {
            var db = new DemoSumm23_AEntities();
            var users = db.Users.ToList();
            return View(Convert(users));
        }
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
        public ActionResult SignUp(UserDTO u) {

            //var test = u.Dob.Date.ToString("yyyy-MM-dd");
            if (ModelState.IsValid) { 
                DemoSumm23_AEntities db = new DemoSumm23_AEntities();
                db.Users.Add(Convert(u));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(u);
        }
        UserDTO Convert(User u) { 
            var user = new UserDTO();   
            user.Username = u.Username;
            user.Gender = u.Gender;
            user.Profession = u.Profession;
            user.Name = u.Name;
            return user;
        }
        User Convert(UserDTO u) {
            var user = new User();
            user.Username = u.Username;
            user.Gender = u.Gender;
            user.Profession = u.Profession;
            user.Name = u.Name;
            return user;
        }
        List<UserDTO> Convert(List<User> us) {
            var users = new List<UserDTO>();
            foreach (var item in us)
            {
                users.Add(Convert(item));
            }
            return users;
        }
    }
}