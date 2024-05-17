using Microsoft.AspNetCore.Mvc;

using PizzaShopManagerApi.Models;
using PizzaShopManagerApi.Models.DataTransferObjects;
using PizzaShopManagerApi.Services;

namespace PizzaShopManagerApi.Controllers;

[Route("/api/pizza")]
[ApiController]
public class PizzaController(IServiceBase<Pizza> service)
    : ApplicationControllerBase
        <Pizza, PizzaDtoPostPut, IServiceBase<Pizza>>(service)
{
}
