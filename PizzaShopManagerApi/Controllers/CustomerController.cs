using Microsoft.AspNetCore.Mvc;

using PizzaShopManagerApi.Models;
using PizzaShopManagerApi.Models.DataTransferObjects;
using PizzaShopManagerApi.Services;

namespace PizzaShopManagerApi.Controllers;

[Route("/api/customer")]
[ApiController]
public class CustomerController(IServiceBase<Customer> service)
    : ApplicationControllerBase
        <Customer, CustomerDtoPostPut, IServiceBase<Customer>>(service)
{
}
