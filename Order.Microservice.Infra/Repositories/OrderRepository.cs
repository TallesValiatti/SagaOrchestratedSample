using Order.Microservice.Domain.Interfaces.Infra;
using Order.Microservice.Infra.Contexts;
using Dapper;
using Order.Microservice.Infra.Queries;
using Order.Microservice.Domain.Entities;

namespace Order.Microservice.Infra.Repositories
{
    public sealed class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Domain.Entities.Order order)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", order.Id);
            parameters.Add("@CreateAt", order.CreateAt);
            parameters.Add("@OrderStatus", order.OrderStatus);

            await _context.Connection.ExecuteAsync(OrderQuery.CreateOrder, parameters, _context.Transaction);

            foreach(var item in order.Itens)
            {
                parameters = new DynamicParameters();
                parameters.Add("@Id", item.Id);
                parameters.Add("@OrderId", order.Id);
                parameters.Add("@Value", item.Value);
                parameters.Add("@ItemId", item.ItemId);
                await _context.Connection.ExecuteAsync(OrderQuery.CreateItem, parameters, _context.Transaction);
            }
        }

        public async Task<IEnumerable<Domain.Entities.Order>> GetAllAsync()
        {
            var lookup = new Dictionary<Guid, Domain.Entities.Order>();
            var result = await _context.Connection.QueryAsync<Domain.Entities.Order, Item, Domain.Entities.Order>(
                        OrderQuery.GetAll, 
                        (order, item) => {
                            Domain.Entities.Order newOrder;
                            if (!lookup.TryGetValue(order.Id, out newOrder!))
                                lookup.Add(order.Id, newOrder = order);

                            if (item != null)
                                newOrder.AddItem(item);                            
                            
                            return newOrder;
                        },
                        splitOn: "Id, Id");

            return result;
        }
    }
}