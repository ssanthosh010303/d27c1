using AutoMapper;

using PizzaShopManagerApi.Models;
using PizzaShopManagerApi.Repositories;

namespace PizzaShopManagerApi.Services;

public class OrderService(IMapper mapper, IRepositoryBase<Order> repository)
    : ServiceBase<Order>(mapper, repository)
{
}
