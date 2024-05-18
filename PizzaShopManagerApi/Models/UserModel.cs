#nullable disable

using System.ComponentModel.DataAnnotations;

namespace PizzaShopManagerApi.Models;

public enum Role
{
    Admin,
    Worker,
    Chef,
    KitchenStaff,
    Cashier,
    DeliveryDriver,
    HumanResource,
    MarketingDept
}

public class User : ModelBase
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [MaxLength(64, ErrorMessage = "Username cannot be more than 64 characters.")]
    public string Username { get; set; }

    [Required]
    [MaxLength(64,
        ErrorMessage = "SHA-256 strings cannot be more than 64 characters in hex format.")]
    public string PasswordHash { get; set; }

    [Required]
    public Role UserRole { get; set; }
}
