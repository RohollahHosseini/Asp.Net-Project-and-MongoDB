using Product_Management.Models.Product;

namespace Product_Management.Repositories.Conteracts.Product
{
    public interface IProductService
    {
        public Task<List<ProductEntity>> GetAllAsync();
        public Task<ProductEntity> GetByIdAsync(string id);
        public Task<bool> CreateAsync(ProductEntity entity);
        public Task<bool> UpdateAsync(string id,ProductEntity entity);
        public Task<bool> DeleteAsync(string id);

    }
}
