using ShopOnline.API.Modules.Carts.Entities;
using ShopOnline.Shared.Common;
using ShopOnline.Shared.Dtos;

namespace ShopOnline.API.Modules.Products.Entities;

public class Product : BaseEntityProperties
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int CategoryId { get; set; }

    public ProductCategory? Category { get; set; }

    public IEnumerable<CartProduct>? CartProducts { get; set; }

    public Product() { }

    public Product(ProductForModificationDto productforModificationDto)
    {
        Name = productforModificationDto.Name;
        Description = productforModificationDto.Description;
        ImageUrl = productforModificationDto.ImageUrl;
        Price = productforModificationDto.Price;
        Quantity = productforModificationDto.Quantity;
        CategoryId = productforModificationDto.CategoryId;
    }

    public Product Update(ProductDto productDto)
    {
        Name = productDto.Name ?? Name;
        Description = productDto.Description ?? Description;
        ImageUrl = productDto.ImageUrl ?? ImageUrl;
        Price = productDto.Price == 0M ? Price : productDto.Price;
        Quantity = productDto.Quantity == 0 ? Quantity : productDto.Quantity;
        CategoryId = productDto.CategoryId == 0 ? CategoryId : productDto.CategoryId;

        return this;
    }

    public ProductDto ToProductDto() => new()
    {
        Id = Id,
        Name = Name,
        Description = Description,
        ImageUrl = ImageUrl,
        Price = Price,
        Quantity = Quantity,
        CategoryId = CategoryId,
        CategoryName = Category?.Name ?? string.Empty
    };
}
