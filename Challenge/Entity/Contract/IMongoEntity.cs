using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge.Entity.Contract
{
    public interface IMongoEntity
    {
        ObjectId _id { get; set; }
    }
}