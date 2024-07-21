using Application.Queries;
using Domain.Aggregates.Accounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlueSoft_test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IMediator mediator,
            ILogger<AccountController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet, Route("account/get-all")]
        public async Task<List<GetAllAccountQuerieResponse>> GetAll()
        {
            var response = await _mediator.Send(new GetAllAccountQuerieRequest());

            return response;
        }

        [HttpGet, Route("account/get-by-id/{id}")]
        public async Task<GetByIdAccountQuerieResponse> GetById(int id)
        {
            var response = await _mediator.Send(new GetByIdAccountQuerieRequest(id));

            return response;
        }
    }
}
