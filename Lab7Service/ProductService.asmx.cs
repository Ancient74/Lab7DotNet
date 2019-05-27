using Lab7Service;
using Lab7Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Lab7Sevice
{
    [WebService(Namespace = "http://lab7_my.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class ProductSevice : System.Web.Services.WebService
    {
        ProductsEntities productsEntities;
        public ProductSevice()
        {
            productsEntities = new ProductsEntities();
        }

        [WebMethod]
        public List<ProductModel> Products()
        {
            return productsEntities.Products.Select(x => new ProductModel { Id = x.Id, Name = x.Name, Price = x.Price }).ToList();
        }

        [WebMethod]
        public ProductModel Product(int id)
        {
            var prod = productsEntities.Products.Find(id);
            if (prod == null)
                return null;

            return new ProductModel(prod);
        }
        [WebMethod]
        public void DeleteProduct(int id)
        {
            productsEntities.Products.Remove(productsEntities.Products.Find(id));
            productsEntities.SaveChanges();
        }

        [WebMethod]
        public void UpdateProduct(int id, ProductModel model)
        {
            var prod = productsEntities.Products.Find(id);
            if (prod == null)
                return;

            prod.Name = model.Name;
            prod.Price = model.Price;
            productsEntities.SaveChanges();
        }

        [WebMethod]
        public void AddProduct(ProductModel model)
        {
            Product product = new Product();
            product.Name = model.Name;
            product.Price = model.Price;
            productsEntities.Products.Add(product);
            productsEntities.SaveChanges();
        }

        [WebMethod]
        public List<CustomerModel> Customers()
        {
            return productsEntities.Customers.Select(x => new CustomerModel { Id = x.Id, Name = x.Name, Age = x.Age }).ToList();
        }

        [WebMethod]
        public CustomerModel Customer(int id)
        {
            var cust = productsEntities.Customers.Find(id);
            if (cust == null)
                return null;

            return new CustomerModel(cust);
        }
        [WebMethod]
        public void DeleteCustomer(int id)
        {
            productsEntities.Customers.Remove(productsEntities.Customers.Find(id));
            productsEntities.SaveChanges();
        }

        [WebMethod]
        public void UpdateCustomer(int id, CustomerModel model)
        {
            var cust = productsEntities.Customers.Find(id);
            if (cust == null)
                return;

            cust.Name = model.Name;
            cust.Age = model.Age;
            productsEntities.SaveChanges();
        }

        [WebMethod]
        public void AddCustomer(CustomerModel model)
        {
            Customer customer = new Customer();
            customer.Name = model.Name;
            customer.Age = model.Age;
            productsEntities.Customers.Add(customer);
            productsEntities.SaveChanges();
        }

        [WebMethod]
        public List<OrderModel> Orders()
        {
            return productsEntities.Orders.Select(x => new OrderModel { Count = x.Count, CustomerId = x.CustomerId, ProductId = x.ProductId }).ToList();
        }

        [WebMethod]
        public OrderModel Order(int id)
        {
            var ord = productsEntities.Orders.Find(id);
            if (ord == null)
                return null;

            return new OrderModel(ord);
        }
        [WebMethod]
        public void DeleteOrder(int id)
        {
            productsEntities.Orders.Remove(productsEntities.Orders.Find(id));
            productsEntities.SaveChanges();
        }

        [WebMethod]
        public void UpdateOrder(int id, OrderModel model)
        {
            var ord = productsEntities.Orders.Find(id);
            if (ord == null)
                return;

            ord.Count = model.Count;
            ord.CustomerId = model.CustomerId;
            ord.ProductId = model.ProductId;
            productsEntities.SaveChanges();
        }

        [WebMethod]
        public void AddOrder(OrderModel model)
        {
            Order ord = new Order();
            ord.Count = model.Count;
            ord.CustomerId = model.CustomerId;
            ord.ProductId = model.ProductId;
            productsEntities.Orders.Add(ord);
            productsEntities.SaveChanges();
        }

    }
}
