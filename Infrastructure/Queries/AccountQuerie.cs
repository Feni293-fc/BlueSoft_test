using Domain.Aggregates.Accounts;
using Domain.Aggregates.Accounts.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries
{
    public class AccountQuerie : IAccountQuerie
    {
        private readonly SqlServerContext _context;

        public AccountQuerie(SqlServerContext context)
        {
            _context = context;
        }

        public Task<List<Account>> GetAll()
        {
            return _context.Accounts.ToListAsync();
        }

        public async Task<Account> GetById(int id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(p => p.accountID == id);
        }
    }
}
