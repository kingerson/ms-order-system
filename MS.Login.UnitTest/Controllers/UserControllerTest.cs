using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MS.Login.Application;
using MS.Login.Controllers;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace MS.Login.UnitTest
{
    public class UserControllerTest
    {
        private readonly UserController _sut;
        private readonly Mock<IUserQuery> _IUserQueryMock;
        public UserControllerTest()
        {
            _IUserQueryMock = new Mock<IUserQuery>();
            _sut = new UserController(_IUserQueryMock.Object);
        }

        [Fact]
        public async Task GetUserInfoVerifyIsCalled()
        {
            // Arrange
            var user = "g.navarrope@gmail.com";
            var password = "Facil123";

            var objectResult = new UserViewModel
            {
                id = 1,
                name = "Gerson"
            };

            _IUserQueryMock.Setup(m => m.GetUserInfo(user, password)).ReturnsAsync(objectResult);

            // Act

            var actual = await _sut.Get(user,password);

            // Assert
            ((ObjectResult)actual).StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
    }
}
