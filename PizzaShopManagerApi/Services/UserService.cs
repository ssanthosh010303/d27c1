using AutoMapper;

using PizzaShopManagerApi.Models;
using PizzaShopManagerApi.Repositories;

namespace PizzaShopManagerApi.Services;

public class UserService(IMapper mapper, IRepositoryBase<User> repository)
    : ServiceBase<User>(mapper, repository)
{
}
