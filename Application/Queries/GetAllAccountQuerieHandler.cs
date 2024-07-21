using Domain.Aggregates.Accounts.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetAllAccountQuerieHandler : IRequestHandler<GetAllAccountQuerieRequest, List<GetAllAccountQuerieResponse>>
    {
        private readonly IAccountService _accountService;

        public GetAllAccountQuerieHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<List<GetAllAccountQuerieResponse>> Handle(GetAllAccountQuerieRequest request, CancellationToken cancellationToken)
        {
            var result = await _accountService.GetAll();
            return result.Select(p => new GetAllAccountQuerieResponse { accountID = p.accountID, balance = p.balance, numberAccount = p.numberAccount, typeAccount = p.typeAccount, city = p.city, customerID = p.customerID }).ToList();
        }
    }
}
