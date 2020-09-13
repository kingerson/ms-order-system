using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MS.Products.Application;
using MS.Products.Controllers;
using MS.Products.Services;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace MS.Product.UnitTest
{
    public class ProductControllerTest
    {
        private readonly ProductController _sut;
        private readonly Mock<IProductQuery> _IProductQueryMock;
        private readonly Mock<IProductRepository> _IProductRepositoryMock;
        private readonly Mock<IDateService> _IDateServiceMock;

        public ProductControllerTest()
        {
            _IProductQueryMock = new Mock<IProductQuery>();
            _IProductRepositoryMock = new Mock<IProductRepository>();
            _IDateServiceMock = new Mock<IDateService>();
            _sut = new ProductController(_IProductQueryMock.Object, _IProductRepositoryMock.Object, _IDateServiceMock.Object);
        }

        [Fact]
        public async Task CreateProductVerifyIsCalled()
        {
            // Arrange
            var product = new MS.Products.Application.Product
            {
                id = 1,
                model = "Producto Nuevo"
            };

            _IDateServiceMock.Setup(m => m.GetDate()).Returns(DateTime.Now);
            _IProductRepositoryMock.Setup(m => m.Create(product)).ReturnsAsync(1);

            // Act

            var actual = await _sut.CreateProduct(product);

            // Assert
            ((ObjectResult)actual).StatusCode.Should().Be((int)HttpStatusCode.Created);
        }

        [Fact]
        public async Task UpdateProductVerifyIsCalled()
        {
            // Arrange
            var product = new MS.Products.Application.Product
            {
                id = 1,
                model = "Producto Nuevo"
            };

            _IDateServiceMock.Setup(m => m.GetDate()).Returns(DateTime.Now);
            _IProductRepositoryMock.Setup(m => m.Update(product)).ReturnsAsync(true);

            // Act

            var actual = await _sut.UpdateProduct(product);

            // Assert
            ((ObjectResult)actual).StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public async Task UpdateStateProductVerifyIsCalled()
        {
            // Arrange
            var product = new MS.Products.Application.Product
            {
                id = 1,
                model = "Producto Nuevo"
            };

            _IDateServiceMock.Setup(m => m.GetDate()).Returns(DateTime.Now);
            _IProductRepositoryMock.Setup(m => m.Update_State(product)).ReturnsAsync(true);

            // Act

            var actual = await _sut.UpdateState(product);

            // Assert
            ((ObjectResult)actual).StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetProductVerifyIsCalled()
        {
            // Arrange
            var product = new MS.Products.Application.Product
            {
                id = 1,
                model = "Producto Nuevo"
            };

            var resultQuery = new ProductViewModel
            {
                id = 1
            };

            _IProductQueryMock.Setup(m => m.GetById(product.id)).ReturnsAsync(resultQuery);

            // Act

            var actual = await _sut.Get(product.id);

            // Assert
            ((ObjectResult)actual).StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetPaginationProductVerifyIsCalled()
        {
            // Arrange
            var productFilter = new ProductFilter
            {
                Page = 1,
                Rows = 10
            };

            var resultQuery = new ProductPaginationViewModel
            {
                Records = 10
            };

            _IProductQueryMock.Setup(m => m.Pagination(productFilter)).ReturnsAsync(resultQuery);

            // Act

            var actual = await _sut.Pagination(productFilter);

            // Assert
            ((ObjectResult)actual).StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

    }
}
