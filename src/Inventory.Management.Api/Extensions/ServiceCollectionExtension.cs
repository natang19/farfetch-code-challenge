using Inventory.Management.Api.Repositories;

namespace Inventory.Management.Api.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<ICategoryRepository, CategoryRepository>();

        return services;
    }
}