using Order.Microservice.Api.Application.Interfaces;
using MediatR;
using Order.Microservice.Domain.Interfaces.Infra;
using Order.Microservice.Domain.Commands.Output;
using Order.Microservice.Domain.Commands.Input;
using AutoMapper;
using Order.Microservice.Api.Application.Dtos.Output;
using Order.Microservice.Api.Application.Dtos.Input;

namespace Order.Microservice.Api.Application.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        public OrderAppService(IMediator mediator, 
                               IOrderRepository orderRepository, 
                               IMapper mapper)
        {
            _mediator = mediator;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<OrderDto>>(await _orderRepository.GetAllAsync());
        }
        public async Task<CommandResult> CreateAsync(CreateOrderDto dto)
        {
            var command = _mapper.Map<CreateOrderCommand>(dto);
            return await _mediator.Send(command);
        }
    }
}