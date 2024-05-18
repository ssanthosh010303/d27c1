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
    [HttpGet]
    [Route("checkaccess")]
    public IActionResult CheckAccess(string username, string role)
    {
        bool hasAccess = _service.CheckAccess(username, role);

        return hasAccess ? Ok() : Forbid();
    }
}
