using PizzaShopManagerApi.Models;

namespace PizzaShopManagerApi.Repositories;

public class CustomerRepository(ApplicationDbContext applicationDbContext)
    : RepositoryBase<Customer>(applicationDbContext)
{
}
