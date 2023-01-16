using Store.Core.Entities;
using Store.Core.Enumerations;
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
        public IQueryable<Product> GetAll(ProductQueryFilters filters)
        {
            var products= _productRepository.GetAll(filters);
            if (filters.ProductName != null)
            {
                products=products.Where(x=>x.Name.Contains(filters.ProductName));
            }
            if(filters.ProductDescription != null)
            {
                products=products.Where(x=>x.Description.Contains(filters.ProductDescription));
            }
            if(filters.ProductCategory!= null)
            {
                products = products.Where(x => x.Category == filters.ProductCategory);
            }
            
            if(filters.OrderByCategory!= null)
            {
                if (filters.OrderByCategory == OrderBy.Ascending)
                {
                    products = products.OrderBy(x => x.Category);
                }
                else
                {
                    products = products.OrderByDescending(x => x.Category);
                }
            }
            if (filters.OrderByName != null)
            {
                if (filters.OrderByName == OrderBy.Ascending)
                {
                    products = products.OrderBy(x => x.Name);
                }
                else
                {
                    products = products.OrderByDescending(x => x.Name);
                }
            }
            return products;
        }
        public async Task<Product> GetById(int id)
        {
            var product = await _productRepository.GetById(id);
            return product;
        }
        public async Task<Product> Insert(Product product)
        {
            await _productRepository.Insert(product);
            return product;
        }
        public async Task<bool> Update(Product product)
        {
            var existingProduct = await _productRepository.GetById(product.Id);
            existingProduct.Description = product.Description;
            existingProduct.Category = product.Category;
            existingProduct.Name = product.Name;
            existingProduct.Image = product.Image;
            await _productRepository.Update(existingProduct);
            return true;
        }
        public async Task Delete(int id)
        {
            await _productRepository.Delete(id);
        }
    }
}
