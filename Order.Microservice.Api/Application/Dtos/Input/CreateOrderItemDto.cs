namespace Order.Microservice.Api.Application.Dtos.Input
{
    public class CreateOrderItemDto
    {
        public Guid Id { get; set; }
        public float Value { get; set; }
    }
}