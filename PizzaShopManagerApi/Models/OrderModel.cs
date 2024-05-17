#nullable disable

using System.ComponentModel.DataAnnotations;

namespace PizzaShopManagerApi.Models;

public class Order : ModelBase
{
    public int CustomerId { get; set; }

    [Required]
    public DateTime OrderDate { get; set; }

    [Required]
    [Range(0, double.MaxValue,
        ErrorMessage = "Total amount must be a positive number.")]
    public decimal TotalAmount { get; set; }

    public Customer Customer { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}
