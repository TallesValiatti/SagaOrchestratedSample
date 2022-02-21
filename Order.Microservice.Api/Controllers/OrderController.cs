using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.Microservice.Domain.Commands.Input;
using Order.Microservice.Domain.Interfaces.Infra;

namespace Order.Microservice.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IOrderRepository _orderRepository;
    public OrderController(IMediator mediator, IOrderRepository orderRepository)
    {
        _mediator = mediator;
        _orderRepository = orderRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Post()
    {
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok();
    }
}
