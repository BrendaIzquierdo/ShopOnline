using Microsoft.EntityFrameworkCore;
using ShopOnline.API.Modules.Products.Entities;
using ShopOnline.Shared.Dtos;

namespace ShopOnline.API.Modules.Products.Extensions;

public static class QueryableExtensions
{
    public static async Task<IList<ProductDto>> GetProductsAsync(this DbSet<Product> products, int? id)
    {
        if (id is null)
        {
            return await products.Include(p => p.Category).Select(product => product.ToProductDto()).ToListAsync();
        }

        return await products.Include(p => p.Category).Where(p => p.Id == id).Select(product => product.ToProductDto()).ToListAsync();
    }
}
