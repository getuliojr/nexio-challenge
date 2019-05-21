using Challenge.Entity.Contract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge.Entity
{
    public class User : IMongoEntity
    {
        [BsonId]
        public ObjectId _id { get; set; }

        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}