
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Pokemon.Common.Entities
{
    public class Pokemones: Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Nombre { get; set; }
        public IList<Poder> Poderes { get; set; }
        public Categoria Categoria { get; set; }
    }
}
