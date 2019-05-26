using Lab7.Model;
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
        public List<ProductModel> Products()
        {
            return productsEntities.Products.Select(x => new ProductModel(x)).ToList();
        }

        [WebMethod]
        public List<CustomerModel> Customers()
        {
            return productsEntities.Customers.Select(x => new CustomerModel(x)).ToList();
        }

        [WebMethod]
        public List<OrderModel> Orders()
        {
            return productsEntities.Orders.Select(x => new OrderModel(x)).ToList();
        }



    }
}
