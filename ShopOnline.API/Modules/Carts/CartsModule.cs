using ShopOnline.API.Interfaces;

namespace ShopOnline.API.Modules.Carts;

public class CartsModule : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection services) => services;

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        RouteGroupBuilder group = endpoints.MapGroup("Carts")
        .WithOpenApi();

        //group.MapGet("/", );

        return group;
    }
}
