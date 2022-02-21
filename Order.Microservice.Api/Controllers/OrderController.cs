using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.Microservice.Api.Application.Interfaces;
using Order.Microservice.Domain.Commands.Input;
using Order.Microservice.Domain.Interfaces.Infra;

namespace Order.Microservice.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : BaseController
{
    private readonly IOrderAppService _orderAppService;
    public OrderController(IOrderAppService orderAppService)
    {
        _orderAppService = orderAppService;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateOrderCommand command)
    {
        return ApiResponse<Guid>(await _orderAppService.CreateAsync(command));
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _orderAppService.GetAllAsync());
    }
}
