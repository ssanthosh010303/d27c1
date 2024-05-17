namespace PizzaShopManagerApi.Models.DataTransferObjects;

public class OrderDtoPostPut : DtoBase
{
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
}
