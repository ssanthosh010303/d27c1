namespace PizzaShopManagerApi.Models.DataTransferObjects;

public class OrderItemDtoPostPut : DtoBase
{
    public int OrderId { get; set; }
    public int PizzaId { get; set; }
    public int Quantity { get; set; }
    public decimal Subtotal { get; set; }
}
