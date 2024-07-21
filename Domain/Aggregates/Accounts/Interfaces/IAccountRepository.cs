using Domain.Aggregates.Movements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.Accounts.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> Update(Account account);
    }
}
