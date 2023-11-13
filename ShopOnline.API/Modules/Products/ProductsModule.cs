using Microsoft.AspNetCore.Http.HttpResults;
using ShopOnline.API.Data;
using ShopOnline.API.Interfaces;
using ShopOnline.API.Modules.Products.Entities;
using ShopOnline.API.Modules.Products.Extensions;
using ShopOnline.Shared.Dtos;

namespace ShopOnline.API.Modules.Products;

public class ProductsModule : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection services) => services;

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        RouteGroupBuilder group = endpoints.MapGroup("Products")
        .WithOpenApi();

        group.MapGet("/", async Task<Results<Ok<IList<ProductDto>>, NotFound, ProblemHttpResult>> (AppDbContext appDbContext, int? id) =>
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
        });

        group.MapPost("/", async Task<Results<Ok<ProductDto>, ProblemHttpResult>> (AppDbContext appDbContext, ProductForModificationDto productForModificationDto, CancellationToken cancellationToken) =>
        {
            try
            {
                Product product = new(productForModificationDto);
                await appDbContext.Products.AddAsync(product);
                await appDbContext.SaveChangesAsync(cancellationToken);

                IList<ProductDto> productDto = await appDbContext.Products.GetProductsAsync(product.Id);
                return TypedResults.Ok(productDto.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return TypedResults.Problem($"Error adding product: {ex.Message}",
                                            statusCode: StatusCodes.Status500InternalServerError);
            }
        });

        group.MapPatch("/{id}", async Task<Results<Ok<ProductDto>, ProblemHttpResult>> (AppDbContext appDbContext, ProductDto productDto, int id, CancellationToken cancellationToken) =>
        {
            try
            {
                Product? product = await appDbContext.Products.FindAsync(id);
                if (product == null)
                {
                    return TypedResults.Problem($"No entry found with Id: {id}", statusCode: StatusCodes.Status404NotFound);
                }

                product.Update(productDto);
                await appDbContext.SaveChangesAsync(cancellationToken);

                return TypedResults.Ok(product.ToProductDto());
            }
            catch (Exception ex)
            {
                return TypedResults.Problem($"Error adding product: {ex.Message}",
                                            statusCode: StatusCodes.Status500InternalServerError);
            }
        });

        group.MapDelete("/{id}", async Task<Results<Ok, ProblemHttpResult>> (AppDbContext appDbContext, int id) =>
        {
            try
            {
                Product? product = await appDbContext.Products.FindAsync(id);
                if (product == null)
                {
                    return TypedResults.Problem($"No entry found with Id: {id}", statusCode: StatusCodes.Status404NotFound);
                }
                appDbContext.Products.Remove(product);
                appDbContext.SaveChanges();

                return TypedResults.Ok();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem($"Error deleting product: {ex.Message}",
                                           statusCode: StatusCodes.Status500InternalServerError);
            }
        });

        /*
        .WithOpenApi()
        .WithDescription("Get all the Products")
        .WithDisplayName("Product")
        .WithSummary("Return Products");
        */

        //group.MapGet("/{id}", GetProductById.Handler);
        /*
        .WithOpenApi()
        .WithDescription("Get a Product by Id")
        .WithDisplayName("Product")
        .WithSummary("Return a Product");
        */

        return group;
    }
}
