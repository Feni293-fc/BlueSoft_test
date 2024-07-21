using Domain.Aggregates.Accounts;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetAllAccountQuerieRequest : IRequest<List<GetAllAccountQuerieResponse>>
    {

    }

    public class GetAllAccountQuerieResponse
    {
        public int accountID { get; set; }
        public string numberAccount { get; set; }
        public decimal balance { get; set; }
        public TypeAccount typeAccount { get; set; }
        public int city { get; set; }
        public int customerID { get; set; }
    }
}
