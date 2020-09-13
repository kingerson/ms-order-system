using Microsoft.AspNetCore.Mvc;
using MS.Login.Application;
using System.Net;
using System.Threading.Tasks;

namespace MS.Login.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserQuery _userQuery;
        public UserController(IUserQuery userQuery)
        {
            _userQuery = userQuery;
        }

        [HttpGet]
        [Route("{email}/{password}")]
        [ProducesResponseType(typeof(UserViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(string email,string password)
        {
            var result = await _userQuery.GetUserInfo(email,password);
            return Ok(result);
        }

    }
}