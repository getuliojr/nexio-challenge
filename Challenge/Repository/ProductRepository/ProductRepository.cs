using Challenge.Entity;
using Challenge.Repository.Context;
using Challenge.Repository.ProductRepository.Contract;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge.Repository.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private IMongoCollection<Product> productCollection;

        public ProductRepository(IMongoContext mongoContext)
        {
            this.productCollection = mongoContext.GetCollection<Product>();
        }

        public void AddProduct(Product p)
        {
            this.productCollection.InsertOne(p);
        }

        public void DeleteProduct(FilterDefinition<Product> filter)
        {
            this.productCollection.DeleteOne(filter);
        }

        public Product GetProduct(FilterDefinition<Product> filter)
        {
            return this.productCollection.Find(filter).FirstOrDefault();
        }

        public IEnumerable<Product> GetProducts(FilterDefinition<Product> filter = null)
        {
            if (filter == null)
                filter = Builders<Product>.Filter.Empty;

            return this.productCollection.Find(filter).ToList();
        }

        public Product UpdateProduct(Product p)
        {
            var filter = Builders<Product>.Filter.Eq(x => x._id, p._id);
            this.productCollection.ReplaceOne(filter, p);

            return p;
        }
    }
}