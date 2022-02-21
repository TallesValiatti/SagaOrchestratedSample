namespace Order.Microservice.Api.Application.Interfaces
{
    public interface IOrderAppService
    {
        Task<IEnumerable<Domain.Entities.Order>> GetAllAsync();
        Task CreateAsync();
    }
}