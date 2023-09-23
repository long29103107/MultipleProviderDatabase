using MongoDB.Bson.Serialization.Attributes;
using Shared.Repository.MongoDb.Domains;
using Shared.Repository.MongoDb.Extensions.Attributes;

namespace Customer.Model.Generate;

[BsonCollection("Customer")]
public class Customer : MongoEntity
{
    [BsonElement("name")]
    public string Name { get; set; }
    [BsonElement("category")]
    public string Category { get; set; }

}
