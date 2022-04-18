using Catalog.Application.Products;

namespace Catalog.Application.Abstraction.Repositories;

public interface IProductsRepository
{
    Task<T> GetAllAsync<T>();
    Task<T> GetAsync<T>(Guid id);
    Task AddAsync<T>(T entity);
    Task Delete(Guid id);

}