using Challenge.Commons.Const;
using Challenge.Entity;
using Challenge.Models.Catalog;
using Challenge.Models.Product;
using Challenge.Repository.ProductRepository.Contract;
using Challenge.Repository.SaleRepository.Contract;
using Challenge.Services.ProductService.Contract;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly ISaleRepository saleRepository;

        public ProductService(IProductRepository productRepository, ISaleRepository saleRepository)
        {
            this.productRepository = productRepository;
            this.saleRepository = saleRepository;
        }

        public ProductModel AddProduct(InsertProductModel model)
        {
            var product = new Product
            {
                _id = ObjectId.GenerateNewId(),
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Price = model.Price
            };

            this.productRepository.AddProduct(product);


            return new ProductModel {
                _id = product._id.ToString(),
                CategoryId = product.CategoryId,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price
            };
        }

        public ProductModel GetProductById(string id)
        {
            var filter = Builders<Product>.Filter.Eq(x => x._id, ObjectId.Parse(id));
            var productsOnSale = saleRepository.GetSales(Builders<Sale>.Filter.Gt(s => s.Expires, DateTime.Now));
            var product = this.productRepository.GetProduct(filter);

            if (product == null)
                throw new Exception(ExceptionMessages.ProductNotFound);

            return new ProductModel
            {
                _id = product._id.ToString(),
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
                Price = product.Price,
                SalePrice = productsOnSale.Where(p => p._idProduct == product._id).FirstOrDefault()?.SalePrice,
                SaleExpiresDate = productsOnSale.Where(p => p._idProduct == product._id).FirstOrDefault()?.Expires
            };
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            var productsOnSale = saleRepository.GetSales(Builders<Sale>.Filter.Gt(s => s.Expires, DateTime.Now));

            return productRepository.GetProducts().Select(x => new ProductModel
            {
                _id = x._id.ToString(),
                Name = x.Name,
                CategoryId = x.CategoryId,
                Price = x.Price,
                Description = x.Description,
                SalePrice = productsOnSale.Where(p => p._idProduct == x._id).FirstOrDefault()?.SalePrice,
                SaleExpiresDate = productsOnSale.Where(p => p._idProduct == x._id).FirstOrDefault()?.Expires
            });
        }

        public IEnumerable<CatalogModel> GetCatalogProducts()
        {
            var productsOnSale = saleRepository.GetSales(Builders<Sale>.Filter.Gt(s => s.Expires, DateTime.Now));

            var products = productRepository.GetProducts().Select(x => new ProductModel
            {
                _id = x._id.ToString(),
                Name = x.Name,
                CategoryId = x.CategoryId,
                Price = x.Price,
                Description = x.Description,
                SalePrice = productsOnSale.Where(p => p._idProduct == x._id).FirstOrDefault()?.SalePrice,
                SaleExpiresDate = productsOnSale.Where(p => p._idProduct == x._id).FirstOrDefault()?.Expires
            });

            var catalogProducts = products.GroupBy(x => x.CategoryId)
               .Select(x => new CatalogModel
               {
                   CategoryName = x.Key.ToString(),
                   Products = x
               });

            return catalogProducts;
        }
    }
}