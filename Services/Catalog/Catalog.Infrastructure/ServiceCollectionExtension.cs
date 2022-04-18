using Catalog.Application.Abstraction;
using Catalog.Infrastructure.Mappings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static void AddCatalogInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IMongoMapper, CatalogMapping>();
        }
    }
}