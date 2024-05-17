#nullable disable

using System.ComponentModel.DataAnnotations;

namespace PizzaShopManagerApi.Models;

public class OrderItem : ModelBase
{
    public int OrderId { get; set; }
    public int PizzaId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
    public int Quantity { get; set; }

    [Required]
    [Range(0, double.MaxValue,
        ErrorMessage = "Subtotal must be a positive number.")]
    public decimal Subtotal { get; set; }

    public Order Order { get; set; }
    public Pizza Pizza { get; set; }
}
