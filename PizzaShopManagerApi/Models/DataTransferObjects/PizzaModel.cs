#nullable disable

namespace PizzaShopManagerApi.Models.DataTransferObjects;

public class PizzaDtoPostPut : DtoBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}
