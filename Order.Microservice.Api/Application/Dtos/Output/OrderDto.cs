using Order.Microservice.Api.Application.Dtos.Output.Common;
using Order.Microservice.Domain.Enums;

namespace Order.Microservice.Api.Application.Dtos.Output
{
    public class OrderDto : Dto
    {
         public float Amount { get;  set; }
        public DateTime CreateAt { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string? OrderStatusDescription { get; set; }
        public IEnumerable<ItemDto>? Itens { get; set; }
    }
}