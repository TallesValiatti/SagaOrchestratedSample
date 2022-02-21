using Order.Microservice.Domain.Commands.Input;
using Order.Microservice.Domain.Entities.Common;
using Order.Microservice.Domain.Enums;

namespace Order.Microservice.Domain.Entities
{
    public sealed class Order : Entity, IAggregateRoot
    {
        public float Amount 
        { 
            get
            {
                return _itens.Sum(x => x.Value);
            } 
        }
        public DateTime CreateAt { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public IReadOnlyList<Item> Itens
        { 
            get
            {
                return _itens.ToList().AsReadOnly();
            } 
        }
        private IList<Item> _itens;

        private Order()
        {
            _itens = new List<Item>();
        }
        private Order(Guid id,
                    DateTime createAt, 
                    OrderStatus orderStatus, 
                    IEnumerable<Item> itens)
        {
            Id = id;
            CreateAt = createAt;
            OrderStatus = orderStatus;
            _itens = itens.ToList();
        }

        public void AddItem(Item item)
        {
            _itens.Add(item);
        }
        public static Order CreateNewOrder(CreateOrderCommand command)
        {
            if(command is null)
                throw new Exception("Command is null");

            if(command!.Itens is null)
                throw new Exception("Itens is null");    

            var orderId = Guid.NewGuid();

            var itens = command.Itens.Select( x => 
            {
                return new Item(Guid.NewGuid(), x.Value, orderId, x.Id);
            }); 

            var order = new Order(orderId,
                                  DateTime.Now,
                                  OrderStatus.Pending,
                                  itens);
            return order;
        }
    }
}