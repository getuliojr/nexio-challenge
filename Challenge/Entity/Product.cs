using Challenge.Commons.Enum;
using Challenge.Entity.Contract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge.Entity
{
    public class Product : IMongoEntity
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public CategoryEnum CategoryId { get; set; }
    }
}