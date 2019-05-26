using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7.Model
{
    public class OrderModel
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}