using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MS.Products.Application
{
    public class ProductQuery : IProductQuery
    {
        private string _connectionString = string.Empty;
        public ProductQuery(string connectionString)
        {
            _connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentException(nameof(connectionString));
        }
        public async Task<ProductViewModel> GetById(int id)
        {
            var result = new ProductViewModel();
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var param = new DynamicParameters();
                param.Add("@id", id);
                result = await cn.QueryFirstOrDefaultAsync<ProductViewModel>(@"[dbo].[sp_get_product_by_id]", param, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public async Task<ProductPaginationViewModel> Pagination(ProductFilter filter)
        {
            var result = new ProductPaginationViewModel();
            using (var cn = new SqlConnection(_connectionString))
            {
                await cn.OpenAsync();
                var param = new DynamicParameters();
                param.Add("@Page", filter.Page, DbType.Int32);
                param.Add("@Rows", filter.Rows, DbType.Int32);
                param.Add("@Records", 1, DbType.Int32, ParameterDirection.InputOutput);
                param.Add("@Total", 1, DbType.Int32, ParameterDirection.InputOutput);

                result.Page = filter.Page;
                result.Rows = await cn.QueryAsync<ProductViewModel>(@"[dbo].[sp_get_product_pagination]", param, commandType: CommandType.StoredProcedure);
                result.Records = param.Get<int>("@Records");
                result.Total = param.Get<int>("@Total");
            }

            return result;
        }

        private IEnumerable<ProductViewModel> GetSupplier()
        {
            var result = new List<ProductViewModel>()
            {
                new ProductViewModel
                {
                    id = 1,
                    code = "1",
                    model = "Producto Rojo",
                    name = "Mercado Libre",
                    producer = "Lima Peru",
                    category = "Mercado Libre",
                    price = 0,
                    is_active = true,
                    register_date = "06-08-2020"
                },
                new ProductViewModel
                {
                    id = 2,
                    code = "2",
                    model = "Producto Rojo",
                    name = "Mercado Libre",
                    producer = "Lima Peru",
                    category = "Mercado Libre",
                    price = 0,
                    is_active = true,
                    register_date = "06-08-2020"
                },
                new ProductViewModel
                {
                    id = 3,
                    code = "3",
                    model = "Producto Rojo",
                    name = "Mercado Libre",
                    producer = "Lima Peru",
                    category = "Mercado Libre",
                    price = 0,
                    is_active = true,
                    register_date = "06-08-2020"
                },
                new ProductViewModel
                {
                    id = 4,
                    code = "4",
                    name = "Mercado Libre",
                    model = "Producto Rojo",
                    producer = "Lima Peru",
                    category = "Mercado Libre",
                    price = 0,
                    is_active = true,
                    register_date = "06-08-2020"
                },
                new ProductViewModel
                {
                    id = 5,
                    code = "5",
                    name = "Mercado Libre",
                    model = "Producto Rojo",
                    producer = "Lima Peru",
                    category = "Mercado Libre",
                    price = 0,
                    is_active = true,
                    register_date = "06-08-2020"
                },
                new ProductViewModel
                {
                    id = 6,
                    code = "6",
                    name = "Mercado Libre",
                    model = "Producto Rojo",
                    producer = "Lima Peru",
                    category = "Mercado Libre",
                    price = 0,
                    is_active = true,
                    register_date = "06-08-2020"
                },
                new ProductViewModel
                {
                    id = 7,
                    code = "7",
                    name = "Mercado Libre",
                    model = "Producto Rojo",
                    producer = "Lima Peru",
                    category = "Mercado Libre",
                    price = 0,
                    is_active = true,
                    register_date = "06-08-2020"
                },
                new ProductViewModel
                {
                    id = 8,
                    code = "8",
                    name = "Mercado Libre",
                    model = "Producto Rojo",
                    producer = "Lima Peru",
                    category = "Mercado Libre",
                    price = 0,
                    is_active = true,
                    register_date = "06-08-2020"
                },
                new ProductViewModel
                {
                    id = 9,
                    code = "9",
                    name = "Mercado Libre",
                    model = "Producto Rojo",
                    producer = "Lima Peru",
                    category = "Mercado Libre",
                    price = 0,
                    is_active = true,
                    register_date = "06-08-2020"
                },
                new ProductViewModel
                {
                    id = 10,
                    code = "10",
                    name = "Mercado Libre",
                    model = "Producto Rojo",
                    producer = "Lima Peru",
                    category = "Mercado Libre",
                    price = 0,
                    is_active = true,
                    register_date = "06-08-2020"
                },
                new ProductViewModel
                {
                    id = 11,
                    code = "11",
                    name = "Mercado Libre",
                    model = "Producto Rojo",
                    producer = "Lima Peru",
                    category = "Mercado Libre",
                    price = 0,
                    is_active = true,
                    register_date = "06-08-2020"
                },
                new ProductViewModel
                {
                    id = 12,
                    code = "12",
                    name = "Mercado Libre",
                    model = "Producto Rojo",
                    producer = "Lima Peru",
                    category = "Mercado Libre",
                    price = 0,
                    is_active = true,
                    register_date = "06-08-2020"
                },new ProductViewModel
                {
                    id = 13,
                    code = "13",
                    name = "Mercado Libre",
                    model = "Producto Rojo",
                    producer = "Lima Peru",
                    category = "Mercado Libre",
                    price = 0,
                    is_active = true,
                    register_date = "06-08-2020"
                }

            };
            return result;
        }
    }
}
