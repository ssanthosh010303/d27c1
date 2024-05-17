#nullable disable

namespace PizzaShopManagerApi.Models.DataTransferObjects;

public class ErrorResponse
{
    public string Message { get; set; }
    public string ErrorCode { get; set; }
}
