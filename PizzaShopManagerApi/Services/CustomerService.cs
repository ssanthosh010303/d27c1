using AutoMapper;

using PizzaShopManagerApi.Models;
using PizzaShopManagerApi.Repositories;

namespace PizzaShopManagerApi.Services;

public class CustomerService(IMapper mapper, IRepositoryBase<Customer> repository)
    : ServiceBase<Customer>(mapper, repository)
{
}
