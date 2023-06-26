using ProductManagement.Auth;
using ProductManagement.DB;
using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        //[AdminAccess]
        public ActionResult Index()
        {
            //if (Session["user"] == null) return RedirectToAction("Index", "Home");
            DemoSumm23_AEntities db = new DemoSumm23_AEntities();
            var orders = db.Orders.ToList();
            return View(Convert(orders));
        }
        public ActionResult Details(int id) {
            DemoSumm23_AEntities db = new DemoSumm23_AEntities();
            var order = db.Orders.Find(id);
            //temporary without DTO
            return View(order);

        }
        public ActionResult Process(int id) {
            DemoSumm23_AEntities db = new DemoSumm23_AEntities();
            var order = db.Orders.Find(id);
            foreach (var item in order.OrderDetails)
            {
                var p = db.Products.Find(item.PId);
                p.Qty -= item.Qty;
            }
            order.Status = "Processing";
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Decline(int id) {
            DemoSumm23_AEntities db = new DemoSumm23_AEntities();
            db.Orders.Find(id).Status = "Declined";
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        OrderDTO Convert(Order od) { 
            var o = new OrderDTO();
            o.Amount = od.Amount;
            o.Status = od.Status;
            o.Date = od.Date;
            o.Id = od.Id;
            return o;
        }
        Order Convert(OrderDTO od) {
            var o = new Order();
            o.Amount = od.Amount;
            o.Status = od.Status;
            o.Date = od.Date;
            o.Id = od.Id;
            return o;
        }
        List<OrderDTO> Convert(List<Order> ods) { 
            var orders = new List<OrderDTO>();
            foreach (var item in ods)
            {
                orders.Add(Convert(item));
            }
            return orders;
        }
    }
}