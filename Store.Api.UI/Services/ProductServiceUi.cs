using Store.Api.UI.Interfaces;
using Store.Core.Entities;
using Store.Core.QueryFilters;

namespace Store.Api.UI.Services
{
    public class ProductServiceUi : IProductServiceUi
    {
        private readonly HttpClient _httpClient;
        public ProductServiceUi(HttpClient httpClient)
        {
            _httpClient= httpClient;
        }

        public async Task<IEnumerable<Product>> GetAll(ProductQueryFilters filters)
        {
            var products = await _httpClient.GetFromJsonAsync<IEnumerable<Product>>($"api/Product?ProductName={filters.ProductName}&ProductDescription={filters.ProductDescription}&ProductCategory={filters.ProductCategory}&OrderByName={filters.OrderByName}&OrderByCategory={filters.OrderByCategory}");
            return products;
        }

        public async Task<Product> GetById(int id)
        {
            var product = await _httpClient.GetFromJsonAsync<Product>($"api/Product/{id}");
            return product;
        }

        public async Task<Product> Insert(Product product)
        {
            await _httpClient.PostAsJsonAsync("api/Product",product);
            return product;
        }

        public async Task<bool> Update(Product product)
        {
            await _httpClient.PutAsJsonAsync($"api/Product/{product.Id}", product);
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Product/{id}");
            return true;
        }
    }
}
