using Dapper;
using MS.ProductsWithoutArtifact.Services;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MS.ProductsWithoutArtifact.Application
{
    public class ProductRepository: IProductRepository
    {
        private string _connectionString = string.Empty;
        private string _formatDateTime = string.Empty;
        public ProductRepository(
            string connectionString, 
            string formatDateTime)
        {
            _connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentException(nameof(connectionString));
            _formatDateTime = !string.IsNullOrWhiteSpace(formatDateTime) ? formatDateTime : throw new ArgumentException(nameof(formatDateTime));
        }

        public async Task<int> Create(Product product)
        {
            var result = default(int);

            var jsonSettings = new JsonSerializerSettings
            {
                DateFormatString = _formatDateTime
            };

            var json = JsonConvert.SerializeObject(product, jsonSettings);

            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var param = new DynamicParameters();
                param.Add("@jsonData", json);
                result = await cn.ExecuteScalarAsync<int>(@"[dbo].[sp_create_product]", param, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public async Task<bool> Update(Product product)
        {
            var result_int = default(int);

            var jsonSettings = new JsonSerializerSettings
            {
                DateFormatString = _formatDateTime
            };

            var json = JsonConvert.SerializeObject(product, jsonSettings);

            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var param = new DynamicParameters();
                param.Add("@jsonData", json);
                result_int = await cn.ExecuteAsync(@"[dbo].[sp_update_product]", param, commandType: CommandType.StoredProcedure);
            }

            return result_int == default(int) ? true : false;
        }

        public async Task<bool> Update_State(Product product)
        {
            var result_int = default(int);

            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var param = new DynamicParameters();
                param.Add("@id", product.id);
                param.Add("@is_active", product.is_active);
                result_int = await cn.ExecuteAsync(@"[dbo].[sp_update_product_state]", param, commandType: CommandType.StoredProcedure);
            }

            return result_int == default(int) ? true : false;
        }
    }
}
