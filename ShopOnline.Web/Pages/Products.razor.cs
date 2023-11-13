using Microsoft.AspNetCore.Components;
using ShopOnline.Shared.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages;

public partial class Products
{
    [Inject]
    public required IProductService ProductService { get; set; }

    public IEnumerable<ProductDto> AllProducts { get; set; } = new List<ProductDto>();

    protected override async Task OnInitializedAsync() =>
        AllProducts = await ProductService.GetProductsAsync();

    protected IOrderedEnumerable<IGrouping<int, ProductDto>> GetGroupedProductsByCategory() =>
        AllProducts.GroupBy(p => p.CategoryId).OrderBy(g => g.Key);

    protected string GetCategoryName(IGrouping<int, ProductDto> grouping) =>
        grouping.FirstOrDefault(pg => pg.CategoryId == grouping.Key)?.CategoryName ?? "";
}
