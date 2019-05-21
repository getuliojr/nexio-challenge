using Challenge.Entity;
using Challenge.Models.Sale;
using Challenge.Repository.ProductRepository.Contract;
using Challenge.Repository.SaleRepository.Contract;
using Challenge.Services.SaleService.Contract;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge.Services.SaleService
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository saleRepository;
        private readonly IProductRepository productRepository;

        public SaleService(ISaleRepository saleRepository, IProductRepository productRepository)
        {
            this.saleRepository = saleRepository;
            this.productRepository = productRepository;
        }

        public void AddProductOnSale(AddProductOnSaleModel model)
        {
            var sale = new Sale
            {
                _id = ObjectId.GenerateNewId(),
                _idProduct = ObjectId.Parse(model.ProductId),
                SalePrice = model.SalePrice,
                Expires = model.Expires
            };

            saleRepository.AddSale(sale);
        }

        public IEnumerable<SaleProduct> GetProductsOnSale()
        {
            var saleProducts = new List<SaleProduct>();

            //Get Sales
            var sales = saleRepository.GetSales();
            
            //Get Products on Sale
            var filterProducts = Builders<Product>.Filter.In(x => x._id, sales.Select(x => x._idProduct));
            var products = productRepository.GetProducts(filterProducts);

            foreach (var sale in sales)
            {
                var product = products.Single(p => p._id == sale._idProduct);
                saleProducts.Add(new SaleProduct
                {
                    ProductName = product.Name,
                    ProductPrice = product.Price,
                    SaleId = sale._id.ToString(),
                    SalePrice = sale.SalePrice
                });
            }

            return saleProducts;
        }
    }
}