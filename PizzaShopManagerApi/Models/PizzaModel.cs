#nullable disable

using System.ComponentModel.DataAnnotations;

namespace PizzaShopManagerApi.Models;

public class Pizza : ModelBase
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    [Range(0, double.MaxValue,
        ErrorMessage = "Price must be a positive number.")]
    public decimal Price { get; set; }
}
