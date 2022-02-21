using Order.Microservice.Api.Application.Dtos.Input;
using Order.Microservice.Api.Application.Dtos.Output;
using Order.Microservice.Domain.Commands.Input;
using Order.Microservice.Domain.Commands.Output;

namespace Order.Microservice.Api.Application.Interfaces
{
    public interface IOrderAppService
    {
        Task<IEnumerable<OrderDto>> GetAllAsync();
        Task<CommandResult> CreateAsync(CreateOrderDto dto);
    }
}