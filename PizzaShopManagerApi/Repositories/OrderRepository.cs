using PizzaShopManagerApi.Models;

namespace PizzaShopManagerApi.Repositories;

public class OrderRepository(ApplicationDbContext applicationDbContext)
    : RepositoryBase<Order>(applicationDbContext)
{
}
