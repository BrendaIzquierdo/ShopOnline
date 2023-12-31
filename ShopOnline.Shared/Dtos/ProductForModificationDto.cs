namespace ShopOnline.Shared.Dtos;

public class ProductForModificationDto
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int CategoryId { get; set; }
}
