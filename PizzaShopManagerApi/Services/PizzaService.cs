using AutoMapper;

using PizzaShopManagerApi.Models;
using PizzaShopManagerApi.Repositories;

namespace PizzaShopManagerApi.Services;

public class PizzaService(IMapper mapper, IRepositoryBase<Pizza> repository)
    : ServiceBase<Pizza>(mapper, repository)
{
}
