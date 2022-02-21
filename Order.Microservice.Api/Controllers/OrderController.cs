using Microsoft.AspNetCore.Mvc;
using Order.Microservice.Api.Application.Dtos.Input;
using Order.Microservice.Api.Application.Interfaces;

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
    public async Task<IActionResult> Post(CreateOrderDto dto)
    {
        return ApiResponse(await _orderAppService.CreateAsync(dto));
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _orderAppService.GetAllAsync());
    }
}
