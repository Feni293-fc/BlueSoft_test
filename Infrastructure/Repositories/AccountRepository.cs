using Domain.Aggregates.Accounts;
using Domain.Aggregates.Accounts.Interfaces;
using Domain.Aggregates.Movements;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SqlServerContext _context;

        public AccountRepository(SqlServerContext context)
        {
            _context = context;
        }

        public Task<Account> Update(Account account)
        {
            _context.Accounts.Update(account);
            _context.SaveChanges();
            Task<Account?> task = _context.Accounts.FirstOrDefaultAsync();
            return task;
        }
    }
}
