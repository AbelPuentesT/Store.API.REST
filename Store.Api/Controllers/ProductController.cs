using Microsoft.AspNetCore.Mvc;
using Store.Core.Entities;
using Store.Core.Enumerations;
using Store.Core.Interfaces;
using Store.Core.QueryFilters;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetAllProducts([FromQuery] ProductQueryFilters filters)
        {
            var products = _productService.GetAll(filters);
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id) 
        { 
            var product= await _productService.GetById(id);
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> InsertAsync(Product product)
        {
            await _productService.Insert(product);
            return Ok(product);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Product product)
        {
            var ExistingProduct = product;
            ExistingProduct.Id = id;
            await _productService.Update(ExistingProduct);
            return Ok(ExistingProduct);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.Delete(id);
            return Ok();
        }

    }
}
