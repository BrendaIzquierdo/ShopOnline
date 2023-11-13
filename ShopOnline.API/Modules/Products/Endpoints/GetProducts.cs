using Microsoft.AspNetCore.Http.HttpResults;
using ShopOnline.API.Data;
using ShopOnline.API.Modules.Products.Extensions;
using ShopOnline.Shared.Dtos;

namespace ShopOnline.API.Modules.Products.Endpoints;

public static class GetProducts
{
    public static async Task<Results<Ok<IList<ProductDto>>, NotFound, ProblemHttpResult>> Handler(AppDbContext appDbContext, int? id)
    {
        try
        {
            IList<ProductDto>? products = await appDbContext.Products.GetProductsAsync(id);
            if (products.Count == 0)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(products);
        }
        catch (Exception e)
        {
            return TypedResults.Problem(detail: $"Error retrieving data: {e.Message}", statusCode: StatusCodes.Status500InternalServerError);
        }
    }
}
