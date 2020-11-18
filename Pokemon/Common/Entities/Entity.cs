using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Pokemon.Common.Entities
{
    public abstract class Entity
    {
        
        public int Id { get; set; }
        /*
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ObjId { get; set; }
        */

    }
}
