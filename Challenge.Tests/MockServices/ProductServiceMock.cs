using Challenge.Commons.Const;
using Challenge.Entity;
using Challenge.Models.Catalog;
using Challenge.Models.Product;
using Challenge.Repository.ProductRepository.Contract;
using Challenge.Repository.SaleRepository.Contract;
using Challenge.Services.ProductService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge.MockServices.ProductServiceMock
{
    public class ProductServiceMock : IProductService
    {
        private readonly List<ProductModel> _mockProducts;
        public ProductServiceMock()
        {
            _mockProducts = new List<ProductModel>();
            _mockProducts.Add(new ProductModel { _id = "1", CategoryId = Commons.Enum.CategoryEnum.Computers, Name = "TestName1", Description = "TestDescription1", Price = 1 });
            _mockProducts.Add(new ProductModel { _id = "2", CategoryId = Commons.Enum.CategoryEnum.Mobile, Name = "TestName2", Description = "TestDescription2", Price = 2 });
            _mockProducts.Add(new ProductModel { _id = "3", CategoryId = Commons.Enum.CategoryEnum.Mobile, Name = "TestName3", Description = "TestDescription3", Price = 3.5 });
            _mockProducts.Add(new ProductModel { _id = "4", CategoryId = Commons.Enum.CategoryEnum.VideoGames, Name = "TestName4", Description = "TestDescription4", Price = 1.5 });
        }

        public ProductModel AddProduct(InsertProductModel model)
        {
            
            var product = new ProductModel
            {
                _id = (_mockProducts.Count + 1).ToString(),
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Price = model.Price
            };

            _mockProducts.Add(product);

            return product;
        }

        public ProductModel GetProductById(string id)
        {
            var product = _mockProducts.FirstOrDefault(x => x._id == id);

            if (product == null)
                throw new Exception(ExceptionMessages.ProductNotFound);

            return product;
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            return _mockProducts;
        }

        public IEnumerable<CatalogModel> GetCatalogProducts()
        {
            var products = _mockProducts;

            var catalogProducts = products.GroupBy(x => x.CategoryId)
               .Select(x => new CatalogModel
               {
                   CategoryName = x.Key.ToString(),
                   Products = x
               }).ToList();

            return catalogProducts;
        }
    }
}