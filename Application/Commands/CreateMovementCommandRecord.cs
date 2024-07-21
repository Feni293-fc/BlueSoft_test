using Application.Queries;
using Domain.Aggregates.Movements;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateMovementCommandRequest : IRequest<CreateMovementCommandResponse>
    {
        public Movement Movement { get; set; }
        public CreateMovementCommandRequest(Movement movement) {
            Movement = movement;
        }
    }

    public class CreateMovementCommandResponse
    {
        public long movementId { get; set; }
        public TypeMovement typeMovement { get; set; }
        public decimal value { get; set; }
        public DateTime date { get; set; }
        public City city {  get; set; }
        public int customerID { get; set; }
        public int accountId { get; set; }
    }
}
