using Microsoft.AspNetCore.Components;
using ShopOnline.Shared.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages;

public partial class ProductDetails
{
    [Parameter]
    public int Id { get; set; }

    [Inject]
    public required IProductService ProductService { get; set; }

    public ProductDto? Product { get; set; }

    public string? ErrorMessage { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Product = await ProductService.GetProductByIdAsync(Id);
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }
}
