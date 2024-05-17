namespace PizzaShopManagerApi.Models;

public abstract class ModelBase
{
    public int Id { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedOn { get; set; }
}
