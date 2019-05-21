using Challenge.Entity;
using Challenge.Repository.Context;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Repository.ProductRepository.Contract
{
    public interface IProductRepository 
    {
        Product GetProduct(FilterDefinition<Product> filter);
        IEnumerable<Product> GetProducts(FilterDefinition<Product> filter = null);
        void AddProduct(Product p);
        Product UpdateProduct(Product p);
        void DeleteProduct(FilterDefinition<Product> filter);
    }
}
