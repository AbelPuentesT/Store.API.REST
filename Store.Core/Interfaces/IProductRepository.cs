using Store.Core.Entities;
using Store.Core.QueryFilters;

namespace Store.Core.Interfaces
{
    public interface IProductRepository
    {
        Task Delete(int id);
        IQueryable<Product> GetAll(ProductQueryFilters filters);
        Task<Product> GetById(int id);
        Task<Product> Insert(Product product);
        Task Update(Product product);
    }
}