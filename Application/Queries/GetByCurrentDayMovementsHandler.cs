using Domain.Aggregates.Movements.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetByCurrentDayMovementsHandler : IRequestHandler<GetByCurrentDayMovementsRequest, List<GetByCurrentDayMovementsResponse>>
    {
        private readonly IMovementService _movementService;

        public GetByCurrentDayMovementsHandler(IMovementService movementService)
        {
            _movementService = movementService;
        }

        async Task<List<GetByCurrentDayMovementsResponse>> IRequestHandler<GetByCurrentDayMovementsRequest, List<GetByCurrentDayMovementsResponse>>.Handle(GetByCurrentDayMovementsRequest request, CancellationToken cancellationToken)
        {
            var result = await _movementService.GetAllMovementsByCurrentDay(request.Date);
            return (List<GetByCurrentDayMovementsResponse>)result.Select(p => new GetByCurrentDayMovementsResponse
            {
                movementId = p.movementId,
                typeMovement = p.typeMovement,
                value = p.value,
                date = p.date,
                city = p.city,
                customerID = p.customerID,
                accountId = p.accountId,
            });
        }
    }
}
