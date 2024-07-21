using Domain.Aggregates.Accounts;
using Domain.Aggregates.Customers;
using Domain.Aggregates.Customers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public sealed class CustomerService : ICustomerService
    {
        private readonly ICustomerQuery _customerQuery;

        public CustomerService(ICustomerQuery customerQuery)
        {
            _customerQuery = customerQuery;
        }

        public Task<Customer> GetById(int id)
        {
            return _customerQuery.GetById(id);
        }
    }
}
