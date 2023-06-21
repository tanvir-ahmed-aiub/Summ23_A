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