using System.Reflection;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Domain.Orders;
using Ordering.Infrastructure.Peristence;

namespace Ordering.Infrastructure;

public static class InfrastructureInstaller
{
    public static void AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
    }
}