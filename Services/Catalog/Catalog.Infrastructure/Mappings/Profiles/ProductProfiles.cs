using AutoMapper;
using Catalog.Application.Products.CreateProduct;
using Catalog.Domain;

namespace Catalog.Infrastructure.Mappings.Profiles;

public class ProductProfiles : Profile
{
    public ProductProfiles()
    {
        CreateMap<Product, CreateProductCommand>();
    }
}