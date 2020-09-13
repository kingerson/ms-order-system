using System.Threading.Tasks;

namespace MS.Login.Application
{
    public interface IUserQuery
    {
        Task<UserViewModel> GetUserInfo(string email, string password);
    }
}
