using AutoMapper;
using Order.Microservice.Domain.Entities;

namespace Order.Microservice.Api.Application.Dtos.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Item, ItemDto>();
            
            CreateMap<Domain.Entities.Order, OrderDto>()
                .ForMember(
                    dest => dest.OrderStatusDescription,
                    opt => opt.MapFrom( src => src.OrderStatus.ToString())
                )
                .ForMember(
                    dest => dest.Itens,
                    opt => opt.MapFrom( src => src.Itens.AsEnumerable())
                );
        }
    }
}