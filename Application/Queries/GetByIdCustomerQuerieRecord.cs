using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetByIdCustomerQuerieRequest : IRequest<GetByIdCustomerQuerieResponse>
    {
        public long CustomerID { get; set; }
        public GetByIdCustomerQuerieRequest(int customerID)
        {
            CustomerID = customerID;
        }
    }

    public class GetByIdCustomerQuerieResponse
    {
        public int CustomerID { get; set; }
        public string nameCustomer { get; set; }
        public TypeCustomer CustomerType { get; set; }
    }
}
