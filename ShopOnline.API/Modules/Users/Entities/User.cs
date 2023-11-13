using ShopOnline.API.Modules.Carts.Entities;
using ShopOnline.Shared.Common;

namespace ShopOnline.API.Modules.Users.Entities;

public class User : BaseEntityProperties
{
    public string UserName { get; set; } = string.Empty;

    public IEnumerable<Cart>? Carts { get; set; }
}
