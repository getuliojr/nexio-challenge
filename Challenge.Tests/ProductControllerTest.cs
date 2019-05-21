using Challenge.Controllers;
using Challenge.MockServices.ProductServiceMock;
using Challenge.Models.Product;
using Challenge.Services.ProductService.Contract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Challenge.Tests
{
    [TestClass]
    public class ProductControllerTest
    {
        ProductController _controller;
        IProductService _productService;

        public ProductControllerTest()
        {
            _productService = new ProductServiceMock();
            _controller = new ProductController(_productService);
            _controller.Request = new HttpRequestMessage();
            _controller.Configuration = new HttpConfiguration();
        }

        [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            var testProducts = _productService.GetProducts() as List<ProductModel>;

            var response = _controller.Get();
            List<ProductModel> content = response.Content.ReadAsAsync<List<ProductModel>>().Result;
            Assert.AreEqual(testProducts.Count, content.Count);

        }

        [TestMethod]
        public void GetProduct_ShouldReturnCorrectProduct()
        {
            var testProducts = _productService.GetProducts() as List<ProductModel>;

            var response = _controller.Get("3");

            ProductModel content = response.Content.ReadAsAsync<ProductModel>().Result;

            Assert.AreEqual(testProducts[2].Name, content.Name);

        }

        [TestMethod]
        public void GetProduct_ShouldNotFindProduct()
        {
            var response = _controller.Get("9");

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public void InsertProduct_ShouldInsertProduct()
        {
            var newItem = new InsertProductModel
            {
                CategoryId = Commons.Enum.CategoryEnum.VideoGames,
                Name = "TestName5",
                Description = "TestDescription5",
                Price = 6
            };

            var content = _controller.Post(newItem);

            ProductModel response = content.Content.ReadAsAsync<ProductModel>().Result;
            var products = _productService.GetProducts() as List<ProductModel>;

            Assert.AreEqual(products.Count, 5);
        }

    }
}
