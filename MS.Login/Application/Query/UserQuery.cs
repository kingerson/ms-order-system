using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MS.Login.Application
{
    public class UserQuery : IUserQuery
    {
        private string _connectionString = string.Empty;
        public UserQuery(string connectionString)
        {
            _connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentException(nameof(connectionString));
        }

        public async Task<UserViewModel> GetUserInfo(string email,string password)
        {
            var result = new UserViewModel();
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var param = new DynamicParameters();
                param.Add("@email", email);
                param.Add("@password", password);
                result = await cn.QueryFirstOrDefaultAsync<UserViewModel>(@"[dbo].[sp_get_user_info]", param, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
