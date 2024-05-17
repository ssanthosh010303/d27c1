using Microsoft.AspNetCore.Mvc;

using PizzaShopManagerApi.Models;
using PizzaShopManagerApi.Models.DataTransferObjects;
using PizzaShopManagerApi.Services;

namespace PizzaShopManagerApi.Controllers;

[Route("/api/order-item")]
[ApiController]
public class OrderItemController(IServiceBase<OrderItem> service)
    : ApplicationControllerBase
        <OrderItem, OrderItemDtoPostPut, IServiceBase<OrderItem>>(service)
{
}
