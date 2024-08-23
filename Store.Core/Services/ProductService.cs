using Store.Core.Entities;
using Store.Core.Enumerations;
using Store.Core.Exceptions;
using Store.Core.Interfaces;
using Store.Core.QueryFilters;

namespace Store.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<Product>> GetAllAsync(ProductQueryFilters filters)
        {
            var products=  await _productRepository.GetAllAsync(filters);
            if (filters.ProductName != null)
            {
                products=products.Where(x=>x.Name.ToLower().Contains(filters.ProductName.ToLower())).ToList();
            }
            if(filters.ProductDescription != null)
            {
                products=products.Where(x=>x.Description.ToLower().Contains(filters.ProductDescription.ToLower())).ToList();
            }
            if(filters.ProductCategory!= null)
            {
                products = products.Where(x => x.Category == filters.ProductCategory).ToList();
            }
            if (filters.OrderByName != null)
            {
                if (filters.OrderByName == OrderBy.Ascending)
                {
                    products = products.OrderBy(x => x.Name).ToList();
                }
                if (filters.OrderByName == OrderBy.Descending)
                {
                    products = products.OrderByDescending(x => x.Name).ToList();
                }
            }
            if (filters.OrderByCategory!= null)
            {
                if (filters.OrderByCategory == OrderBy.Ascending)
                {
                    products = products.OrderBy(x => x.Category).ToList();
                }
                if(filters.OrderByCategory==OrderBy.Descending)
                {
                    products = products.OrderByDescending(x => x.Category).ToList();
                }
            }
            return products.ToList();
        }
        public async Task<Product> GetById(int id)
        {
            var product = await _productRepository.GetById(id);
            return product ?? throw new BusinessException($"Product with ID {id} not found.");
        }
        public async Task<Product> Insert(Product product)
        {
            await _productRepository.Insert(product);
            return product;
        }
        public async Task<bool> Update(Product product)
        {
            var existingProduct = await _productRepository.GetById(product.Id);
            if (existingProduct == null)
            {
               return false;
            }
            existingProduct.Description = product.Description;
            existingProduct.Category = product.Category;
            existingProduct.Name = product.Name;
            existingProduct.Image = product.Image;
            await _productRepository.Update(existingProduct);
            return true;
        }
        public async Task Delete(int id)
        {
            await GetById(id);
            await _productRepository.Delete(id);
        }
    }
}
