using Application.Queries;
using BlueSoft_test.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(IMediator mediator,
            ILogger<CustomerController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet, Route("customer/get-by-id/{id}")]
        public async Task<GetByIdCustomerQuerieResponse> GetById(int id)
        {
            var response = await _mediator.Send(new GetByIdCustomerQuerieRequest(id));

            return response;
        }
    }
}
