using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS.Suppliers.Application.Commands
{
    public class SupplierRepository : ISupplierRepository
    {
        private string _connectionString = string.Empty;
        public SupplierRepository(string connectionString)
        {
            _connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentException(nameof(connectionString));
        }
    }
}
