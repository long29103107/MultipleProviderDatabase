using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Repository.MongoDb.Domains;
public abstract class MongoEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("_id")]
    public string Id { get; set; }


    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; }
    [BsonElement("createdBy")]
    public string CreatedBy { get; set; }

    [BsonElement("updatedAt")]
    public DateTime UpdatedAt { get; set; }
    [BsonElement("updatedBy")]
    public string UpdatedBy { get; set; }

    [BsonElement("deletedAt")]
    public DateTime? DeletedAt { get; set; }
    [BsonElement("deletedBy")]
    public string DeletedBy { get; set; }
}
