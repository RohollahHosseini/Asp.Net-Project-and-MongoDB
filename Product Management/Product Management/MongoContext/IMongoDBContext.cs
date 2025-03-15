using MongoDB.Driver;

namespace Product_Management.MongoContext
{
    public interface IMongoDBContext
    {
        public IMongoCollection<T> GetCollection<T>();
    }
}
