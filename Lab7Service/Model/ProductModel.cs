using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7Service.Model
{
    public class ProductModel
    {
        public ProductModel()
        {

        }
        public ProductModel(Product product)
        {
            Id = product.Id;
            Price = product.Price;
            Name = product.Name;
        }
        public int Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
    }
}