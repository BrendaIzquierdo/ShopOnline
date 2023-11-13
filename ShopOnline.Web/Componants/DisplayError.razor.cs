using Microsoft.AspNetCore.Components;

namespace ShopOnline.Web.Componants;

public partial class DisplayError
{
    [Parameter]
    public string ErrorMessage { get; set; } = string.Empty;
}
