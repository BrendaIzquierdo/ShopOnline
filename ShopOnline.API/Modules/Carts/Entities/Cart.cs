using ShopOnline.API.Modules.Users.Entities;
using ShopOnline.Shared.Common;

namespace ShopOnline.API.Modules.Carts.Entities;

public class Cart : BaseEntityProperties
{
    public int UserId { get; set; }
    public User? User { get; set; }

    public IEnumerable<CartProduct>? CartProducts { get; set; }
}
