using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.Customers
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string nameCustomer { get; set; } 
        public TypeCustomer CustomerType { get; set; }
    }
}
