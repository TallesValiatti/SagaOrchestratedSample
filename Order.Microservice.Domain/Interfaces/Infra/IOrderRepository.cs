namespace Order.Microservice.Domain.Interfaces.Infra
{
    public interface IOrderRepository
    {
        Task CreateAsync(Entities.Order order);
        Task<IEnumerable<Entities.Order>> GetAllAsync();
    }
}