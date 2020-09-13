using System.Threading.Tasks;

namespace MS.Suppliers.Application.Queries
{
    public interface ISupplierQuery
    {
        Task<SupplierPaginationViewModel> Pagination(SupplierFilter filter);
        Task<SupplierViewModel> GetById(int id);
    }
}
