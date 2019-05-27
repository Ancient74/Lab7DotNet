using Lab7Service;
using Lab7Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab7MVC.Controllers
{
    public class OrderModelExt
    {
        public string CustomerName { get; set; }
        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
    public class OrderController : Controller
    {
        ProductService service = new ProductService();

        OrderModelExt FromOrderModel(OrderModel model)
        {
            OrderModelExt res = new OrderModelExt();
            res.Count = model.Count;
            res.CustomerId = model.CustomerId;
            res.CustomerName = service.Customer(model.CustomerId).Name;
            res.ProductId = model.ProductId;
            var p  = service.Product(model.ProductId);
            res.ProductName =p.Name;
            res.ProductPrice =p.Price;
            return res;
        }

        // GET: Order
        public ActionResult Index()
        {
            return View(service.Orders().Select(x=>FromOrderModel(x)));
        }

        private void FillViewBag()
        {
            ViewBag.Customers = service.Customers().Select(x => new SelectListItem{ Text = x.Name, Value = x.Id.ToString() });
            ViewBag.Products = service.Products().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
        }
        // GET: Order/Details/5
        public ActionResult Details(int customerId, int productId)
        {
            return View(FromOrderModel(service.Order(customerId, productId)));
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            FillViewBag();
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                OrderModel model = new OrderModel
                {
                    CustomerId = int.Parse(collection["Customers"]),
                    ProductId = int.Parse(collection["Products"]),
                    Count = int.Parse(collection["Count"])
                };
                service.AddOrder(model);
                return RedirectToAction("Index");
            }
            catch
            {
                FillViewBag();
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int customerId,int productId)
        {
            FillViewBag();
            return View(FromOrderModel(service.Order(customerId, productId)));
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int customerId,int productId, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                OrderModel model = new OrderModel
                {
                    CustomerId = int.Parse(collection["Customers"]),
                    ProductId = int.Parse(collection["Products"]),
                    Count = int.Parse(collection["Count"])
                };
                service.UpdateOrder(customerId, productId, model);
                return RedirectToAction("Index");
            }
            catch
            {
                FillViewBag();
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int customerId,int productId)
        {
            return View(FromOrderModel(service.Order(customerId, productId)));
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int customerId,int productId, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                service.DeleteOrder(customerId, productId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
