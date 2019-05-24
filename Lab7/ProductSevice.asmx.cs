using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Lab7
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
        public dynamic Products()
        {
            return productsEntities.Products.Select(x => new { Id = x.Id, Name = x.Name, Price = x.Price }).ToList();
        }

        [WebMethod]
        public dynamic Customers()
        {
            return productsEntities.Customers.Select(x => new { Id = x.Id, Name = x.Name, Age = x.Age }).ToList();
        }

        [WebMethod]
        public dynamic Orders()
        {
            return productsEntities.Orders.Select(x => new { Count = x.Count, CustomerId = x.CustomerId, ProductId = x.ProductId }).ToList();
        }

    }
}
