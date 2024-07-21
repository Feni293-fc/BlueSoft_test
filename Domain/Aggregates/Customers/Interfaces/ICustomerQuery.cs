using Domain.Aggregates.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.Customers.Interfaces
{
    public interface ICustomerQuery
    {
        Task<Customer> GetById(int id);
    }
}
