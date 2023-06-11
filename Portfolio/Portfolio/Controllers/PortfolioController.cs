using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: Portfolio
        public ActionResult Index()
        {
            ViewBag.Name = "Tanvir Ahmed";
            ViewBag.Bio = "fgdfgfdg";
            return View();
        }
        public ActionResult Education() {
            var e1 = new Education() { 
                Title="BSc",
                Year = "3rd",
                Ins = "AIUB"

            };
            var e2 = new Education() { 
                Title = "HSC",
                Year = "2019",
                Ins ="DHAKA"
            };
            var e3 = new Education()
            {
                Title = "SSC",
                Year = "2017",
                Ins = "DHAKA"
            };
            Education[] eds = new Education[] { e1, e2, e3 };
            
            return View(eds);
        }
    }
}