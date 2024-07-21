using Application.Commands;
using Application.Queries;
using BlueSoft_test.Controllers;
using Domain.Aggregates.Movements;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovementController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MovementController> _logger;

        public MovementController(IMediator mediator,
            ILogger<MovementController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost, Route("movement/insert-movement")]
        public async Task<CreateMovementCommandResponse> Insert([FromBody] Movement request)
        {
            var response = await _mediator.Send(new CreateMovementCommandRequest(request));

            return response;
        }

        [HttpGet, Route("account/get-by-current-day")]
        public async Task<List<GetByCurrentDayMovementsResponse>> GetByCurrentDay()
        {
            var date = DateTime.Now;
            var response = await _mediator.Send(new GetByCurrentDayMovementsRequest(date));

            return response;
        }
    }
}
