using Product_Management.Repositories.Conteracts.Product;

namespace Product_Management.Repositories.Conteracts.Common
{
    public interface IUnitOfWork
    {
        public IProductService productService { get; }

    }
}
