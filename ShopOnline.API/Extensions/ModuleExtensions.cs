using ShopOnline.API.Interfaces;

namespace ShopOnline.API.Extensions;

public static class ModuleExtensions
{
    private static readonly List<IModule> RegisteredModules = new();

    public static IServiceCollection RegisterModules(this IServiceCollection services)
    {
        IEnumerable<IModule> modules = DiscoverModules();
        foreach (IModule module in modules)
        {
            module.RegisterModule(services);
            RegisteredModules.Add(module);
        }

        return services;
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        foreach (IModule module in RegisteredModules)
        {
            module.MapEndpoints(app);
        }

        return app;
    }

    private static IEnumerable<IModule> DiscoverModules() => typeof(IModule).Assembly
        .GetTypes()
        .Where(p => p.IsClass && p.IsAssignableTo(typeof(IModule)))
        .Select(Activator.CreateInstance)
        .Cast<IModule>();
}
