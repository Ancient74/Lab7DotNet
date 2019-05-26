using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7.Model
{
    public class OrderModel
    {
        public OrderModel()
        {

        }
        public OrderModel(Order order)
        {
            ProductId = order.ProductId;
            CustomerId = order.CustomerId;
            Count = order.Count;
        }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}