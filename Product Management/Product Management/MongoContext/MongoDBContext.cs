using MongoDB.Driver;

namespace Product_Management.MongoContext
{
    public class MongoDBContext : IMongoDBContext
    {
        private readonly IMongoDatabase database;

        public MongoDBContext(IConfiguration configuration)
        {
            var connectionString = configuration["MongoDB:ConnectionString"];
            var databaseName = configuration["MongoDB:DatabaseName"];

            var client = new MongoClient(connectionString);
            database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return database.GetCollection<T>(typeof(T).Name);
        }
    }
}
