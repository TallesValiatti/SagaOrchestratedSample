using Flunt.Notifications;

namespace Order.Microservice.Domain.Entities.Common
{
    public abstract class Entity
    {
        public Guid Id { get; internal set; }
    }
}