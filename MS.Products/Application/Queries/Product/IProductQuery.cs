using System.Threading.Tasks;

namespace MS.Products.Application
{
    public interface IProductQuery
    {
        Task<ProductPaginationViewModel> Pagination(ProductFilter filter);
        Task<ProductViewModel> GetById(int id);
    }
}
