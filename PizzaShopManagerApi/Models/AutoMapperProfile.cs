using AutoMapper;

using PizzaShopManagerApi.Models.DataTransferObjects;

namespace PizzaShopManagerApi.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<PizzaDtoPostPut, Pizza>();
        CreateMap<CustomerDtoPostPut, Customer>();
        CreateMap<OrderDtoPostPut, Order>();
        CreateMap<OrderItemDtoPostPut, OrderItem>();
    }
}
