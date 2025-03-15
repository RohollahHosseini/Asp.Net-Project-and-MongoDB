using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Product_Management.Models.Product
{
    public sealed  class ProductEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string ProductName { get; set; } 
        public string ProductDescription { get; set; }
        public float Price { get; set; }
        public bool IsDeleted { get;set; }
    }
}
