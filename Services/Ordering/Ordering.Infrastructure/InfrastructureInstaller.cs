using System.Reflection;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Domain.Orders;

namespace Ordering.Infrastructure;

public static class InfrastructureInstaller
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OrderingContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Ordering"));
        });

        services.AddScoped<IOrderRepository, OrderRepository>();
    }
    
    public static void AddMapster(this IServiceCollection services, Assembly assembly)
    {
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        typeAdapterConfig.Scan(assembly);
    }
}