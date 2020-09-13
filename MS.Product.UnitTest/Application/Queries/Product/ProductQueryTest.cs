using FluentAssertions;
using Moq;
using MS.Products.Application;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MS.Product.UnitTest.Application.Queries
{
    public class ProductQueryTest
    {
        private string _connectionString = "default"; 
        private readonly ProductQuery _sut;
        private readonly Mock<IProductQuery> _productQueryMock;
        public ProductQueryTest()
        {
            _productQueryMock = new Mock<IProductQuery>();
            _sut = new ProductQuery(_connectionString);
        }

        [Fact]
        public async Task ListPaginationCount()
        {
            // Arrange
            var filter = new ProductFilter
            {
                Page = 1,
                Rows = 10
            };

            var objectsList = new ProductPaginationViewModel() { Rows = new List<ProductViewModel> { new ProductViewModel { code = "001" } } };
            var searchResults = Task.FromResult(objectsList);

            _productQueryMock.Setup(m => m.Pagination(filter)).Returns(searchResults);

            // Act
            var actual = await _productQueryMock.Object.Pagination(filter);

            // Assert
            actual.Rows.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task GetProductVerifyExist()
        {
            // Arrange
            var id = 1;

            var objectResult = new ProductViewModel
            {
                id = 1
            };

            _productQueryMock.Setup(m => m.GetById(id)).ReturnsAsync(objectResult);

            // Act
            var actual = await _productQueryMock.Object.GetById(id);

            // Assert

            actual.id.Should().Be(id);
        }
    }
}
