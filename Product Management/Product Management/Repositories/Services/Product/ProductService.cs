using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Product_Management.Models.Product;
using Product_Management.MongoContext;
using Product_Management.Repositories.Conteracts.Product;

namespace Product_Management.Repositories.Services.Product
{
    public class ProductService:IProductService
    {
        private readonly IMongoCollection<ProductEntity> _mongoCollection;

        public ProductService(IMongoDBContext mongoDBContext)
        {
            _mongoCollection = mongoDBContext.GetCollection<ProductEntity>();
        }

        public async Task<bool> CreateAsync(ProductEntity entity)
        {
            await _mongoCollection.InsertOneAsync(entity);

            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
           var result= await _mongoCollection.DeleteOneAsync(c=>c.ProductId==id);
            return result.DeletedCount > 0;
        }

        public async Task<List<ProductEntity>> GetAllAsync()
        {
          return await _mongoCollection.Find(_=>true).ToListAsync();
        }

        public async Task<ProductEntity> GetByIdAsync(string id)
        {
            return await _mongoCollection.AsQueryable().FirstOrDefaultAsync(c=>c.ProductId==id);
        }

        public async Task<bool> UpdateAsync(string id,ProductEntity entity)
        {
            var result= await _mongoCollection.ReplaceOneAsync(c => c.ProductId == id, entity);

            return result.ModifiedCount > 0;
        }
    }
}
