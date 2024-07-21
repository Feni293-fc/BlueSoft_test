using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetByCurrentDayMovementsRequest : IRequest<List<GetByCurrentDayMovementsResponse>>
    {
        public DateTime Date { get; set; }
        public GetByCurrentDayMovementsRequest(DateTime date)
        {
            Date = date;
        }
    }

    public class GetByCurrentDayMovementsResponse
    {
        public long movementId { get; set; }
        public TypeMovement typeMovement { get; set; }
        public decimal value { get; set; }
        public DateTime date { get; set; }
        public City city { get; set; }
        public int customerID { get; set; }
        public int accountId { get; set; }
    }
}
