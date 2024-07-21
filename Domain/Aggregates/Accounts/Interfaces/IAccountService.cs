using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.Accounts.Interfaces
{
    public interface IAccountService : IAccountQuerie, IAccountRepository
    {
    }
}
