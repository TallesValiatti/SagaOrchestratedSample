using System.ComponentModel.DataAnnotations;

#nullable disable
namespace Order.Microservice.Api.Application.Dtos.Input
{
    public class CreateOrderDto
    {
        public IEnumerable<CreateItemDto> Itens { get; set; }
    }
}