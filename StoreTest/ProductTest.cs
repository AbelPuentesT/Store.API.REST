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
        public Mock<IProductService> mock = new Mock<IProductService>();
        public ProductQueryFilters filters = new ProductQueryFilters();

        [Fact]
        public void GetAllProductsTest()
        {
            //arrange
            ProductController products = new ProductController(mock.Object);
            //act
            var result = products.GetAllProducts(filters);
            //assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetAllProductsTestValueAsync()
        {
            ProductController products = new ProductController(mock.Object);
            var result = (OkObjectResult) await products.GetAllProducts(filters);
            var resultType= Assert.IsType<Product[]>(result.Value);
        }

        [Fact]
        public async void GetProductByIdTest()
        {
            //arrange
            var ExistingProduct = new Product()
            {
                Id = 1,
                Name = "TestName",
                Description = "TestDescription",
                Category = (Store.Core.Enumerations.Category)1,
                Image = "TestImage"
            };
            mock.Setup(p => p.GetById(1)).ReturnsAsync(ExistingProduct);
            ProductController product = new ProductController(mock.Object);
            //act
            var result = await product.GetByIdAsync(ExistingProduct.Id);
            //assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetProductByIdTestValue()
        {
            //arrange
            var ExistingProduct = new Product()
            {
                Id = 1,
                Name = "TestName",
                Description = "TestDescription",
                Category = (Store.Core.Enumerations.Category)1,
                Image = "TestImage"
            };
            mock.Setup(p => p.GetById(1)).ReturnsAsync(ExistingProduct);
            ProductController product = new ProductController(mock.Object);
            //act
            var result = (OkObjectResult)await product.GetByIdAsync(ExistingProduct.Id);
            //assert
            Assert.IsType<Product>(result.Value);
        }

        [Fact]
        public async void GetProductByIdExist()
        {
            //arrange
            var ExistingProduct = new Product()
            {
                Id = 1,
                Name = "TestName",
                Description = "TestDescription",
                Category = (Store.Core.Enumerations.Category)1,
                Image = "TestImage"
            };
            mock.Setup(p => p.GetById(1)).ReturnsAsync(ExistingProduct);
            ProductController product = new ProductController(mock.Object);
            //act
            var result = (OkObjectResult)await product.GetByIdAsync(ExistingProduct.Id);
            //assert
            var productExist=Assert.IsType<Product>(result?.Value);
            Assert.True(productExist !=null);
            Assert.Equal(productExist?.Id, ExistingProduct.Id);

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
        public async void InsertProductTestValue()
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
            var result = (OkObjectResult)await product1.InsertAsync(InsertProduct);
            //assert
            Assert.IsType<Product>(result.Value);
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
            var result = await product1.UpdateAsync(1,Updateproduct);
            //assert
            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async void UpdetProductTestValue()
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
            var result = (OkObjectResult)await product1.UpdateAsync(1,Updateproduct);
            //assert
            Assert.IsType<Product>(result.Value);

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

        [Fact]
        public async void DeleteProductTestValue()
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
            var result = (OkResult)await product1.Delete(Deleteproduct.Id);
            //assert
            Assert.IsType<int>(result.StatusCode);
        }
    }
}