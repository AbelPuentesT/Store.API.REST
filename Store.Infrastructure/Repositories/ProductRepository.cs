using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;
using Store.Core.Exceptions;
using Store.Core.Interfaces;
using Store.Core.QueryFilters;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _storeDbContext;
        public ProductRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }
        public async Task<List<Product>> GetAllAsync(ProductQueryFilters filters)
        {
            var products = _storeDbContext.Products.AsQueryable();
            return await products.ToListAsync();
        }

        public async Task<Product?> GetById(int id)
        {
            var product = await _storeDbContext.Products.FindAsync(id);
            return product;
        }
        public async Task<Product> Insert(Product product)
        {
            await _storeDbContext.Products.AddAsync(product);
            await _storeDbContext.SaveChangesAsync();
            return product;
        }
        public async Task Update(Product product)
        {
            _storeDbContext.Products.Update(product);
            await _storeDbContext.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var product = await GetById(id);
            if (product != null)
            {
                _storeDbContext.Products.Remove(product);
                await _storeDbContext.SaveChangesAsync();
            }
        }
    }
}
