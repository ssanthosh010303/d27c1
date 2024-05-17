using Microsoft.AspNetCore.Mvc;

using PizzaShopManagerApi.Models;
using PizzaShopManagerApi.Models.DataTransferObjects;
using PizzaShopManagerApi.Services;

namespace PizzaShopManagerApi.Controllers;

[Route("/api/order")]
[ApiController]
public class OrderController(IServiceBase<Order> service)
    : ApplicationControllerBase
        <Order, OrderDtoPostPut, IServiceBase<Order>>(service)
{
}
