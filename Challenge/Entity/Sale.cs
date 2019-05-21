using Challenge.Entity.Contract;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge.Entity
{
    public class Sale : IMongoEntity
    {
        public ObjectId _id { get; set; }
        public ObjectId _idProduct { get; set; }
        public double SalePrice { get; set; }
        public DateTime Expires { get; set; }
    }
}