using PizzaShopManagerApi.Models;

namespace PizzaShopManagerApi.Repositories;

public class OrderItemRepository(ApplicationDbContext applicationDbContext)
    : RepositoryBase<OrderItem>(applicationDbContext)
{
}
