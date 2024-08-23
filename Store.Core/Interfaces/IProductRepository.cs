using Store.Core.Entities;
using Store.Core.QueryFilters;

namespace Store.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(ProductQueryFilters filters);
        Task<Product?> GetById(int id);
        Task<Product> Insert(Product product);
        Task Update(Product product);
        Task Delete(int id);
    }
}