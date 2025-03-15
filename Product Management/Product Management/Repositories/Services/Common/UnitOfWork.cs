using Product_Management.Models.Product;
using Product_Management.MongoContext;
using Product_Management.Repositories.Conteracts.Common;
using Product_Management.Repositories.Conteracts.Product;
using Product_Management.Repositories.Services.Product;

namespace Product_Management.Repositories.Services.Common
{
    public class UnitOfWork:IUnitOfWork
    {
        public IProductService productService { get;}

        public UnitOfWork(IMongoDBContext mongoDBContext)
        {
            productService = new ProductService(mongoDBContext);
        }
    }
}
