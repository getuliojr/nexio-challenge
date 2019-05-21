using Challenge.Entity;
using Challenge.Repository.Context;
using Challenge.Repository.SaleRepository.Contract;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge.Repository.SaleRepository
{
    public class SaleRepository : ISaleRepository
    {
        private readonly IMongoCollection<Sale> saleCollection;

        public SaleRepository(IMongoContext context)
        {
            saleCollection = context.GetCollection<Sale>();
        }

        public void AddSale(Sale sale)
        {
            saleCollection.InsertOne(sale);
        }

        public IEnumerable<Sale> GetSales(FilterDefinition<Sale> filter = null)
        {
            if (filter == null)
                filter = Builders<Sale>.Filter.Gt(s => s.Expires, DateTime.Now);

            return saleCollection.Find(filter).ToList();
        }

        public void RemoveSale(string _id)
        {
            var filter = Builders<Sale>.Filter.Eq(x => x._id, ObjectId.Parse(_id));
            saleCollection.DeleteOne(filter);
        }
    }
}