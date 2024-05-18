#nullable disable

namespace PizzaShopManagerApi.Models.DataTransferObjects;

public class UserDtoPostPut : DtoBase
{
    public string Username { get; set; }
    public string Password { get; set; }
}
