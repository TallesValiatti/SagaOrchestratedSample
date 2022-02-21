using Flunt.Notifications;
using MediatR;
using Order.Microservice.Domain.Commands.Output;

namespace Order.Microservice.Domain.Commands.Input
{
    public class CreateOrderCommand : Notifiable<Notification>, 
                                      IRequest<CommandResult<Guid>>
    {
        public IEnumerable<CreateItemCommand>? Itens { get; private set; }
        public CreateOrderCommand(IEnumerable<CreateItemCommand>? itens)
        {
            if (itens is null)
                throw new Exception("Request is null");

            if (!Itens!.Any())
                AddNotification("Itens", "There are no itens in the order");

            if (Itens!.Any(x => x.Value <= (float)0))
                AddNotification("Itens", "All itens must have value greater than 0");

            Itens = itens;
        }
    }
}