using Microsoft.AspNetCore.Mvc;
using Moq;
using Store.Api.Controllers;
using Store.Core.Entities;
using Store.Core.Interfaces;
using Store.Core.QueryFilters;

namespace StoreTest
{
    public class ProductTest 
    {
        public Mock <IProductService> mock= new Mock <IProductService> ();
        public ProductQueryFilters filters= new ProductQueryFilters ();

        [Fact]
        public void GetAllProductsTest()
        {
            ProductController products = new ProductController(mock.Object);
            var result = products.GetAllProducts(filters);
            Assert.IsType<OkObjectResult>(result);
            
        }
        [Fact]
        public async void GetProductByIdTest()
        {
            var ExistingProduct = new Product()
            {
                Id = 1,
                Name = "TestName",
                Description = "TestDescription",
                Category = (Store.Core.Enumerations.Category)1,
                Image = "TestImage"
            };
            mock.Setup(p => p.GetById(1)).ReturnsAsync(ExistingProduct);
            
            ProductController product= new ProductController(mock.Object);
            var result = await product.GetByIdAsync(ExistingProduct.Id);
            //Assert.True(product1.Equals(result));
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void InsertProductTest()
        {
            //arrange
            var InsertProduct = new Product()
            {
                Id = 1,
                Name = "TestName",
                Description = "TestDescription",
                Category = (Store.Core.Enumerations.Category)1,
                Image = "TestImage"
            };
            mock.Setup(p => p.Insert(InsertProduct)).ReturnsAsync(InsertProduct);
            ProductController product1 = new ProductController(mock.Object);
            //act
            var result = await product1.InsertAsync(InsertProduct);
            //assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async void UpdetProductTest()
        {
            //arrange
            var Updateproduct = new Product()
            {
                Id = 1,
                Name = "TestName",
                Description = "TestDescription",
                Category = (Store.Core.Enumerations.Category)1,
                Image = "TestImage"
            };
            mock.Setup(p => p.Update(Updateproduct)).ReturnsAsync(true);
            ProductController product1 = new ProductController(mock.Object);
            //act
            var result = await product1.UpdateAsync(1, Updateproduct);
            //assert
            Assert.IsType<OkObjectResult>(result);

        }
        [Fact]
        public async void DeleteProductTest()
        {
            //arrange
            var Deleteproduct = new Product()
            {
                Id = 1,
                Name = "TestName",
                Description = "TestDescription",
                Category = (Store.Core.Enumerations.Category)1,
                Image = "TestImage"
            };
            mock.Setup(p => p.Delete(1));
            ProductController product1 = new ProductController(mock.Object);
            //act
            var result = await product1.Delete(Deleteproduct.Id);
            //assert
            Assert.IsType<OkResult>(result);



        }
    }
}