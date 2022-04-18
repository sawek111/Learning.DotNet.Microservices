namespace Catalog.Application.Abstraction.Repositories;

public interface IRepository<T> where T : class
{
    Task<T> GetAllAsync<T>() where T : class;
    Task<T> Get(int id);
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(int id);
}