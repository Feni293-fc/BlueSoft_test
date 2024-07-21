using Application.Queries;
using Domain.Aggregates.Movements;
using Domain.Aggregates.Movements.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateMovementCommandHandler : IRequestHandler<CreateMovementCommandRequest, CreateMovementCommandResponse>
    {
        private readonly IMovementService _movementService;
        public CreateMovementCommandHandler(IMovementService movementService)
        {
            _movementService = movementService;
        }

        public async Task<CreateMovementCommandResponse> Handle(CreateMovementCommandRequest request, CancellationToken cancellationToken)
        {
            var entry = Mapper(request);
            var result = await _movementService.Insert(entry);
            return new CreateMovementCommandResponse { value = result.value, customerID = result.customerID, accountId = result.accountId, city = result.city, typeMovement = result.typeMovement, date = result.date };
        }

        private Movement Mapper(CreateMovementCommandRequest request)
        {
            Movement movement = new Movement();
            movement.value = request.Movement.value;
            movement.customerID = request.Movement.customerID;
            movement.accountId = request.Movement.accountId;
            movement.city = request.Movement.city;
            movement.typeMovement = request.Movement.typeMovement;
            movement.date = DateTime.UtcNow;

            return movement;
        }
    }
}
