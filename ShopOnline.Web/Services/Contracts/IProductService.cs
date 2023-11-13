using ShopOnline.Shared.Dtos;

namespace ShopOnline.Web.Services.Contracts;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetProductsAsync();
    Task<ProductDto?> GetProductByIdAsync(int id);
}
