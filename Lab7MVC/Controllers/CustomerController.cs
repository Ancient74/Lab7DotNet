using Lab7Service;
using Lab7Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab7MVC.Controllers
{
    public class CustomerController : Controller
    {
        ProductService service = new ProductService();

        public CustomerController()
        {

        }
        // GET: Customer
        public ActionResult Index()
        {
            return View(service.Customers());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View(service.Customer(id));
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                CustomerModel model = new CustomerModel();
                model.Age = int.Parse(collection["Age"]);
                model.Name = collection["Name"];
                service.AddCustomer(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View(service.Customer(id));
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                CustomerModel model = new CustomerModel();
                model.Age = int.Parse(collection["Age"]);
                model.Name = collection["Name"];
                service.UpdateCustomer(id, model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View(service.Customer(id));
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                service.DeleteCustomer(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
