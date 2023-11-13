using ShopOnline.Shared.Common;

namespace ShopOnline.API.Modules.Products.Entities;

public class ProductCategory : BaseEntityProperties
{
    public string Name { get; set; } = string.Empty;

    public IEnumerable<Product>? Products { get; set; }
}
