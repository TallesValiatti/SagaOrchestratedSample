using Order.Microservice.Api.Application.Dtos.Output.Common;

namespace Order.Microservice.Api.Application.Dtos.Output
{
    public class ItemDto : Dto
    {
        public Guid OrderId { get; private set; }
        public Guid ItemId { get; private set; }
        public float Value { get; private set; }
    }
}