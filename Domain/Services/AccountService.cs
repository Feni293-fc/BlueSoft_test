using Domain.Aggregates.Accounts;
using Domain.Aggregates.Accounts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public sealed class AccountService : IAccountService
    {
        private readonly IAccountQuerie _accountQuerie;
        private readonly IAccountRepository _accountRepository;   

        public AccountService(IAccountQuerie accountQuerie, IAccountRepository accountRepository)
        {
            _accountQuerie = accountQuerie;
            _accountRepository = accountRepository; 
        }

        public async Task<List<Account>> GetAll()
        {
            return await _accountQuerie.GetAll();
        }

        public async Task<Account> GetById(int id)
        {
            return await _accountQuerie.GetById(id);
        }

        public async Task<Account> Update(Account account)
        {
            return await _accountRepository.Update(account);
        }
    }
}
