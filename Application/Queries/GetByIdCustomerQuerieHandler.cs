using Domain.Aggregates.Customers.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetByIdCustomerQuerieHandler : IRequestHandler<GetByIdCustomerQuerieRequest, GetByIdCustomerQuerieResponse>
    {
        private readonly ICustomerService _customerService;

        public GetByIdCustomerQuerieHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<GetByIdCustomerQuerieResponse> Handle(GetByIdCustomerQuerieRequest request, CancellationToken cancellationToken)
        {
            var result = await _customerService.GetById((int)request.CustomerID);
            return new GetByIdCustomerQuerieResponse { CustomerID = result.CustomerID, nameCustomer = result.nameCustomer, CustomerType = result.CustomerType };
        }
    }
}
