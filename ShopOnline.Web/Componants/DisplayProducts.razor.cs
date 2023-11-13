using Microsoft.AspNetCore.Components;
using ShopOnline.Shared.Dtos;

namespace ShopOnline.Web.Componants;

public partial class DisplayProducts
{
    [Parameter]
    public required IEnumerable<ProductDto> Products { get; set; }
}
