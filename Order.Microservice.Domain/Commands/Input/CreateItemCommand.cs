using Flunt.Notifications;
using MediatR;
using Order.Microservice.Domain.Commands.Output;

namespace Order.Microservice.Domain.Commands.Input
{
    public class CreateItemCommand : Notifiable<Notification>, 
                                      IRequest<CommandResult<Guid>>
    {
        public Guid ItemId { get; private set; }
        public float Value { get; private set; }
        public CreateItemCommand(float value, Guid itemId)
        {
            Value = value;
            ItemId = itemId;
        }
    }
}