#nullable disable

namespace PizzaShopManagerApi.Models.DataTransferObjects;

public class CustomerDtoPostPut : DtoBase
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
}
