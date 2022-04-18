using Catalog.Application.Abstraction;
using Catalog.Application.Abstraction.Repositories;
using Catalog.Infrastructure.Mappings;
using Catalog.Infrastructure.Mappings.Profiles;
using Catalog.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static void AddCatalogInfrastructureServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductProfiles));
            services.AddScoped<IMongoMapper, CatalogMapping>();
            services.AddScoped<ICatalogContext, CatalogContext>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
        }
    }
}