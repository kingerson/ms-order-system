using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MS.Suppliers.Application.Queries
{
    public class SupplierQuery : ISupplierQuery
    {
        private string _connectionString = string.Empty;
        public SupplierQuery(string connectionString)
        {
            _connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentException(nameof(connectionString));
        }

        public async Task<SupplierViewModel> GetById(int id)
        {
            var result = new SupplierViewModel
            {
                id = id,
                code = "1",
                name = "Mercado Libre",
                adress = "Lima Peru",
                contact_person = "Mercado Libre",
                register_date = "06-08-2020"
            };

            return await Task.FromResult(result);
        }

        public async Task<SupplierPaginationViewModel> Pagination(SupplierFilter filter)
        {
            var result = new SupplierPaginationViewModel();
            result.Rows = GetSupplier();
            result.Page = filter.Page;
            result.Records = 10;
            result.Total = 10;
            return await Task.FromResult(result);
        }

        private IEnumerable<SupplierViewModel> GetSupplier()
        {
            var result = new List<SupplierViewModel>()
            {
                new SupplierViewModel
                {
                    id = 1,
                    code = "1",
                    name = "Mercado Libre",
                    adress = "Lima Peru",
                    contact_person = "Mercado Libre",
                    register_date = "06-08-2020"
                },
                new SupplierViewModel
                {
                    id = 2,
                    code = "2",
                    name = "Mercado Libre",
                    adress = "Lima Peru",
                    contact_person = "Mercado Libre",
                    register_date = "06-08-2020"
                },
                new SupplierViewModel
                {
                    id = 3,
                    code = "3",
                    name = "Mercado Libre",
                    adress = "Lima Peru",
                    contact_person = "Mercado Libre",
                    register_date = "06-08-2020"
                },
                new SupplierViewModel
                {
                    id = 4,
                    code = "4",
                    name = "Mercado Libre",
                    adress = "Lima Peru",
                    contact_person = "Mercado Libre",
                    register_date = "06-08-2020"
                },
                new SupplierViewModel
                {
                    id = 5,
                    code = "5",
                    name = "Mercado Libre",
                    adress = "Lima Peru",
                    contact_person = "Mercado Libre",
                    register_date = "06-08-2020"
                },
                new SupplierViewModel
                {
                    id = 6,
                    code = "6",
                    name = "Mercado Libre",
                    adress = "Lima Peru",
                    contact_person = "Mercado Libre",
                    register_date = "06-08-2020"
                },
                new SupplierViewModel
                {
                    id = 7,
                    code = "7",
                    name = "Mercado Libre",
                    adress = "Lima Peru",
                    contact_person = "Mercado Libre",
                    register_date = "06-08-2020"
                },
                new SupplierViewModel
                {
                    id = 8,
                    code = "8",
                    name = "Mercado Libre",
                    adress = "Lima Peru",
                    contact_person = "Mercado Libre",
                    register_date = "06-08-2020"
                },
                new SupplierViewModel
                {
                    id = 9,
                    code = "9",
                    name = "Mercado Libre",
                    adress = "Lima Peru",
                    contact_person = "Mercado Libre",
                    register_date = "06-08-2020"
                },
                new SupplierViewModel
                {
                    id = 10,
                    code = "10",
                    name = "Mercado Libre",
                    adress = "Lima Peru",
                    contact_person = "Mercado Libre",
                    register_date = "06-08-2020"
                }
            };
            return result;
        }
    }
}
