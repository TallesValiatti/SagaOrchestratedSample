using Order.Microservice.Api.Application.Interfaces;
using MediatR;
namespace Order.Microservice.Api.Application.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IMediator _mediator;
        public OrderAppService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IEnumerable<Domain.Entities.Order>> GetAllAsync()
        {
            return new List<Domain.Entities.Order>();
        }
        public async Task CreateAsync()
        {

        }
    }
}