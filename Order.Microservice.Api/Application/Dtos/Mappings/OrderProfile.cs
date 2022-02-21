using AutoMapper;
using Order.Microservice.Api.Application.Dtos.Input;
using Order.Microservice.Api.Application.Dtos.Output;
using Order.Microservice.Domain.Commands.Input;
using Order.Microservice.Domain.Entities;

namespace Order.Microservice.Api.Application.Dtos.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            // Input
            CreateMap<CreateItemDto, CreateItemCommand>();
            CreateMap<CreateOrderDto, CreateOrderCommand>()
                .ForMember(
                    dest => dest.Itens,
                    opt => opt.MapFrom( src => src.Itens!.AsEnumerable())
                );

            // Output
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