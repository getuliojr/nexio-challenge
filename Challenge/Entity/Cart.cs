using Challenge.Entity.Contract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge.Entity
{
    public class Cart : IMongoEntity
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public ObjectId _idUser { get; set; }
        public IList<Product> Products { get; set; }
    }
}