namespace Order.Microservice.Api.Application.Dtos.Input
{
    public class CreateOrderDto
    {
        public IEnumerable<CreateOrderItemDto>? Itens { get; set; }
    }
}