using MediatR;
using Order.Microservice.Domain.Commands.Input;
using Order.Microservice.Domain.Commands.Output;
using Order.Microservice.Domain.Interfaces.Infra;

namespace Order.Microservice.Domain.Handlers
{
    public class OrderCommandHandler : IRequestHandler<CreateOrderCommand, CommandResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        public OrderCommandHandler(IUnitOfWork unitOfWork, IOrderRepository orderRepository)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
        }
        public async Task<CommandResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid)
                return CommandResult.CreateFailedResult(command.Notifications.Select(x => x.Message));
            
            _unitOfWork.BeginTransaction();
            
            var order = Entities.Order.CreateNewOrder(command);

            try
            {
                await _orderRepository.CreateAsync(order);
                _unitOfWork.Commit();
            }
            catch (System.Exception)
            {
                _unitOfWork.Rollback();
                return CommandResult.CreateFailedResult(new string[] {"Error while saving Order"});
            }
           
            return CommandResult.CreateSuccessedResult(order.Id);
        }
    }
}