namespace ShopOnline.Shared.Dtos;

public class CartProductDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CartId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string ProductDescription { get; set; } = string.Empty;
    public string MyProperty { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal TotalPrice { get; set; }
    public int Quantity { get; set; }
}
