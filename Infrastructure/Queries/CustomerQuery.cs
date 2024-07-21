using Domain.Aggregates.Accounts;
using Domain.Aggregates.Customers;
using Domain.Aggregates.Customers.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries
{
    public class CustomerQuery : ICustomerQuery
    {
        private readonly SqlServerContext _context;

        public CustomerQuery(SqlServerContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetById(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(p => p.CustomerID == id);
        }
    }
}
