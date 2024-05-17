using AutoMapper;

using PizzaShopManagerApi.Models;
using PizzaShopManagerApi.Repositories;

namespace PizzaShopManagerApi.Services;

public class OrderItemService(IMapper mapper, IRepositoryBase<OrderItem> repository)
    : ServiceBase<OrderItem>(mapper, repository)
{
}
