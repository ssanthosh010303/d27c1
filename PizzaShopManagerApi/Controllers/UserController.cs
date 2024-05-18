using Microsoft.AspNetCore.Mvc;

using PizzaShopManagerApi.Models;
using PizzaShopManagerApi.Models.DataTransferObjects;
using PizzaShopManagerApi.Services;

namespace PizzaShopManagerApi.Controllers;

[Route("/api/user")]
[ApiController]
public class UserController(IServiceBase<User> service)
    : ApplicationControllerBase
        <User, UserDtoPostPut, IServiceBase<User>>(service)
{
}
