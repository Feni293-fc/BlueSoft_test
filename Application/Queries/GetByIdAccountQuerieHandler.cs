using Domain.Aggregates.Accounts.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetByIdAccountQuerieHandler : IRequestHandler<GetByIdAccountQuerieRequest, GetByIdAccountQuerieResponse>
    {
        private readonly IAccountService _accountService;

        public GetByIdAccountQuerieHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<List<GetAllAccountQuerieResponse>> Handle(GetAllAccountQuerieRequest request, CancellationToken cancellationToken)
        {
            var result = await _accountService.GetAll();
            return result.Select(p => new GetAllAccountQuerieResponse { accountID = p.accountID, balance = p.balance, numberAccount = p.numberAccount, typeAccount = p.typeAccount }).ToList();
        }

        public async Task<GetByIdAccountQuerieResponse> Handle(GetByIdAccountQuerieRequest request, CancellationToken cancellationToken)
        {
            var result = await _accountService.GetById((int)request.AccountID);
            return new GetByIdAccountQuerieResponse { accountID = result.accountID, balance = result.balance, numberAccount = result.numberAccount, typeAccount = result.typeAccount, city = result.city, customerID = result.customerID };
        }
    }
}
