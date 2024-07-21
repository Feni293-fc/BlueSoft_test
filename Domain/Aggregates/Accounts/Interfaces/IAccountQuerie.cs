using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.Accounts.Interfaces
{
    public interface IAccountQuerie
    {
        Task<List<Account>> GetAll();

        Task<Account> GetById(int id);
    }
}
