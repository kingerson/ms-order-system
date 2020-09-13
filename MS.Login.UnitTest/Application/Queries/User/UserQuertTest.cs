using FluentAssertions;
using Moq;
using MS.Login.Application;
using System.Threading.Tasks;
using Xunit;

namespace MS.Login.UnitTest.Application.Queries
{
    public class UserQuertTest
    {
        private string _connectionString = "default";
        private readonly UserQuery _sut;
        private readonly Mock<IUserQuery> _userQueryMock;
        public UserQuertTest()
        {
            _userQueryMock = new Mock<IUserQuery>();
            _sut = new UserQuery(_connectionString);
        }

        [Fact]
        public async Task GetUserVerifyExist()
        {
            // Arrange
            var user = "g.navarrope@gmail.com";
            var password = "Facil123";

            var objectResult = new UserViewModel
            {
                id = 1,
                name = "Gerson"
            };

            _userQueryMock.Setup(m => m.GetUserInfo(user,password)).ReturnsAsync(objectResult);

            // Act
            var actual = await _userQueryMock.Object.GetUserInfo(user, password);

            // Assert

            actual.id.Should().BeGreaterThan(0);
        }
    }
}
