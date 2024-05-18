using PizzaShopManagerApi.Models;

namespace PizzaShopManagerApi.Repositories;

public class UserRepository(ApplicationDbContext applicationDbContext)
    : RepositoryBase<User>(applicationDbContext)
{
}
