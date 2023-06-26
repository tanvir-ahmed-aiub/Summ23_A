using ProductManagement.DB;
using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            DemoSumm23_AEntities db = new DemoSumm23_AEntities();
            var products = db.Products.ToList();
            return View(Convert(products));
        }
        [HttpGet]
        public ActionResult Edit(int id) {
            DemoSumm23_AEntities db = new DemoSumm23_AEntities();
            var product = db.Products.Find(id);
            return View(Convert(product));
        }
        [HttpPost]
        public ActionResult Edit(ProductDTO p) {
            DemoSumm23_AEntities db = new DemoSumm23_AEntities();
            var exp = db.Products.Find(p.Id);
            exp.Name = p.Name;
            exp.Price = p.Price;
            exp.Qty = p.Qty;
            exp.Description = p.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id) {
            DemoSumm23_AEntities db = new DemoSumm23_AEntities();
            var exp = db.Products.Find(id);
            db.Products.Remove(exp); 
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Add(int id) {
            DemoSumm23_AEntities db = new DemoSumm23_AEntities();
            var p = db.Products.Find(id);
            var product = Convert(p);
            product.Qty = 1;
            List<ProductDTO> cart = null;
            if (Session["cart"] != null)
            {
                cart =(List<ProductDTO>) Session["cart"]; //unboxing
            }
            else { 
                cart = new List<ProductDTO>();
            }
            cart.Add(product);
            Session["cart"] = cart; //
            TempData["Msg"] = "Product Added Successfully";
            return RedirectToAction("Index");
        }
        public ActionResult Cart() {
            var cart = (List<ProductDTO>)Session["cart"];
            if (cart != null) {
                return View(cart);
            }
            TempData["Msg"] = "Cart is Empty";
            return RedirectToAction("Index");
        }
        public ActionResult Checkout() {
            var db = new DemoSumm23_AEntities();
            var order = new Order();
            order.Date = DateTime.Now;
            order.Status = "Ordered";
            db.Orders.Add(order);
            
            var cart = (List<ProductDTO>)Session["cart"];
            var total = 0;
            foreach (var p in cart) {
                var od = new OrderDetail();
                od.OId = order.Id;
                od.PId = p.Id;
                od.Qty = p.Qty;
                od.Price = p.Price;
                total += p.Price * p.Qty;
                db.OrderDetails.Add(od);
            }
            order.Amount = total;
            
            db.SaveChanges();
            Session["cart"] = null;
            TempData["Msg"] = "Order Placed Successfully with Order Id " + order.Id;
            return RedirectToAction("Index");
        }
        ProductDTO Convert(Product p) {
            var pr = new ProductDTO() {
                Id = p.Id,
                Name = p.Name,
                Qty = p.Qty,
                Description = p.Description,
                Price = p.Price

            };
            return pr;
        }
        Product Convert(ProductDTO p)
        {
            var pr = new Product()
            {
                Id = p.Id,
                Name = p.Name,
                Qty = p.Qty,
                Description = p.Description,
                Price = p.Price

            };
            return pr;
        }
        List<ProductDTO> Convert(List<Product> ps) {
            var products = new List<ProductDTO>();
            foreach (var item in ps)
            {
                products.Add(Convert(item));
            }
            return products;
        }

    }
}