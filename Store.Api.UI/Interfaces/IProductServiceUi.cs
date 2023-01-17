using Store.Core.Entities;
using Store.Core.QueryFilters;

namespace Store.Api.UI.Interfaces
{
    public interface IProductServiceUi
    {
        Task<IEnumerable<Product>> GetAll(ProductQueryFilters filtres);
        Task<Product> GetById(int id);
        Task<Product> Insert(Product product);
        Task<bool> Update(int id, Product product);
        Task<bool> Delete(int id);
    }
}
