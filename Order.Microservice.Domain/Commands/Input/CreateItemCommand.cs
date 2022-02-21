using Flunt.Notifications;
using MediatR;
using Order.Microservice.Domain.Commands.Output;

namespace Order.Microservice.Domain.Commands.Input
{
    public class CreateItemCommand : Notifiable<Notification>, 
                                      IRequest<CommandResult<Guid>>
    {
        public Guid Id { get; set; }
        public float Value { get; set; }
        public CreateItemCommand(float value, Guid id)
        {
            Value = value;
            Id = id;
        }
    }
}