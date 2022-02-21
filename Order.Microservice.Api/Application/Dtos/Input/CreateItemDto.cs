namespace Order.Microservice.Api.Application.Dtos.Input
{
    public class CreateItemDto
    {
        public Guid ItemId { get; set; }
        public float Value { get; set; }
    }
}