using Order.Microservice.Domain.Entities.Common;

namespace Order.Microservice.Domain.Entities
{
    public sealed class Item : Entity 
    {
        public Guid OrderId { get; private set; }
        public Guid ItemId { get; private set; }
        public float Value { get; private set; }

        private Item(){}
        public Item(Guid id, float value, Guid orderId, Guid itemId)
        {
            Id = id;
            Value = value;
            OrderId = orderId;
            ItemId = itemId;
        }
    }
}