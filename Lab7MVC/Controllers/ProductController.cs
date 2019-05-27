using Lab7Service;
using Lab7Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab7MVC.Controllers
{
    public class ProductController : Controller
    {

        ProductService productSevice = new ProductService();
        public ProductController()
        {

        }
        // GET: Product
        public ActionResult Index()
        {
            return View(productSevice.Products());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View(productSevice.Product(id));
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                ProductModel model = new ProductModel();
                model.Name = collection["Name"];
                model.Price = double.Parse(collection["Price"]);
                productSevice.AddProduct(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View(productSevice.Product(id));
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                ProductModel model = new ProductModel();
                model.Name = collection["Name"];
                model.Price = double.Parse(collection["Price"]);
                productSevice.UpdateProduct(id, model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View(productSevice.Product(id));
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                productSevice.DeleteProduct(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
