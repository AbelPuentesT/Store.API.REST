using Store.Core.Entities;
using Store.Core.QueryFilters;

namespace Store.Core.Interfaces
{
    public interface IProductService
    {
        IQueryable<Product> GetAll(ProductQueryFilters filters);
        Task<Product> GetById(int id);
        Task<Product> Insert(Product product);
        Task<bool> Update(Product product);
        Task Delete(int id);
    }
}