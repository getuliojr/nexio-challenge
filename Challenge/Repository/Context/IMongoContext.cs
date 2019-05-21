using Challenge.Entity.Contract;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Repository.Context
{
    public interface IMongoContext
    {
        IMongoCollection<T> GetCollection<T>();
    }
}
