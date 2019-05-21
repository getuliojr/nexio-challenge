using Challenge.Entity.Contract;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Challenge.Repository.Context
{
    public class MongoContext : IMongoContext
    {
        private IMongoDatabase Database;
        public MongoContext(IMongoClient client)
        {
            Database = client.GetDatabase(ConfigurationManager.AppSettings["db.name"]);
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return this.Database.GetCollection<T>(typeof(T).Name);
        }
    }
}