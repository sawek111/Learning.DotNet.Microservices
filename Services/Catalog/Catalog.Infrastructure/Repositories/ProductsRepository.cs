using AutoMapper;
using Catalog.Application.Abstraction.Repositories;
using Catalog.Domain;
using Catalog.Domain.Product;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

public class ProductsRepository : IProductsRepository
{
    private readonly ICatalogContext _context;
    private readonly IMapper _mapper;

    public ProductsRepository(ICatalogContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<T> GetAllAsync<T>()
    {
        var entities = await _context.Products.Find(x => true).ToListAsync();
        return _mapper.Map<T>(entities);
    }

    public async Task<T> GetAsync<T>(Guid id)
    {
        var entities = await _context.Products.Find(x => x.Id == id).SingleAsync();
        return _mapper.Map<T>(entities);
    }

    public Task AddAsync<T>(T entity)
    {
        if (entity is not Product product)
        {
            throw new ArgumentException("Entity is not a Product");
        }

        return _context.Products.InsertOneAsync(product);
    }

    public Task Delete(Guid id)
    {
        return _context.Products.DeleteOneAsync(x => x.Id == id);
    }
}