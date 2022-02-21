using Order.Microservice.Api.Application.Dtos;
using Order.Microservice.Domain.Commands.Input;
using Order.Microservice.Domain.Commands.Output;

namespace Order.Microservice.Api.Application.Interfaces
{
    public interface IOrderAppService
    {
        Task<IEnumerable<OrderDto>> GetAllAsync();
        Task<CommandResult<Guid>> CreateAsync(CreateOrderCommand dto);
    }
}