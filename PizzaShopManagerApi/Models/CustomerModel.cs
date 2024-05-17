#nullable disable

using System.ComponentModel.DataAnnotations;

namespace PizzaShopManagerApi.Models;

public class Customer : ModelBase
{
    [Required]
    [MaxLength(64, ErrorMessage = "Name cannot be more than 64 characters.")]
    public string Name { get; set; }

    [Required]
    [Phone(ErrorMessage = "Invalid phone number provided.")]
    public string Phone { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address provided.")]
    [MaxLength(256, ErrorMessage = "Email cannot be more than 256 characters.")]
    public string Email { get; set; }

    public List<Order> Orders { get; set; }
}
