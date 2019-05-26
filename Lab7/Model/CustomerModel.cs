using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7.Model
{
    public class CustomerModel
    {
        public CustomerModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            Age = customer.Age;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}