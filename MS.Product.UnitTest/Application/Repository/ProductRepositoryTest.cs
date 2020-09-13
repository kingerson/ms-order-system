using FluentAssertions;
using Moq;
using MS.Products.Application;
using System.Threading.Tasks;
using Xunit;

namespace MS.Product.UnitTest.Application
{
    public class ProductRepositoryTest
    {
        private string _connectionString = "default";
        private string _formatDateTime = "default";
        private readonly ProductRepository _sut;
        private readonly Mock<IProductRepository> _productRepositoryMock;
        public ProductRepositoryTest()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _sut = new ProductRepository(_connectionString, _formatDateTime);
        }

        [Fact]
        public async Task CreateProductVerify()
        {
            // Arrange
            var newProduct = new MS.Products.Application.Product 
            { 
                id = 1
            };

            _productRepositoryMock.Setup(m => m.Create(newProduct)).ReturnsAsync(1);

            //Act
            var actual = await _productRepositoryMock.Object.Create(newProduct);

            //Asert

            actual.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task UpdateProductVerify()
        {
            // Arrange
            var product = new MS.Products.Application.Product
            {
                id = 1,
                model = "New Model"
            };

            _productRepositoryMock.Setup(m => m.Update(product)).ReturnsAsync(true);

            //Act
            var actual = await _productRepositoryMock.Object.Update(product);

            //Asert

            actual.Should().Be(true);
        }

        [Fact]
        public async Task UpdateStateProductVerify()
        {
            // Arrange
            var product = new MS.Products.Application.Product
            {
                id = 1,
                is_active = false
            };

            _productRepositoryMock.Setup(m => m.Update_State(product)).ReturnsAsync(true);

            //Act
            var actual = await _productRepositoryMock.Object.Update_State(product);

            //Asert

            actual.Should().Be(true);
        }
    }
}
