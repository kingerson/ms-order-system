using System.Threading.Tasks;

namespace MS.ProductsWithoutArtifact.Application
{
    public interface IProductRepository
    {
        Task<int> Create(Product product);
        Task<bool> Update(Product product);
        Task<bool> Update_State(Product product);
    }
}
