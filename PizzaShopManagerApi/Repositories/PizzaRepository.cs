using PizzaShopManagerApi.Models;

namespace PizzaShopManagerApi.Repositories;

public class PizzaRepository(ApplicationDbContext applicationDbContext)
    : RepositoryBase<Pizza>(applicationDbContext)
{
}
