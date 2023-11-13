using ShopOnline.API.Modules.Products.Entities;
using ShopOnline.Shared.Common;

namespace ShopOnline.API.Modules.Carts.Entities;

public class CartProduct : BaseEntityProperties
{
    public int Quantity { get; set; }

    public int CartId { get; set; }
    public Cart? Cart { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }
}
