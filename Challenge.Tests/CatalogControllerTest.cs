using Challenge.Controllers;
using Challenge.MockServices.ProductServiceMock;
using Challenge.Models.Catalog;
using Challenge.Services.ProductService.Contract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace Challenge.Tests
{
    [TestClass]
    public class CatalogControllerTest
    {
        CatalogController _controller;
        IProductService _productService;

        public CatalogControllerTest()
        {
            _productService = new ProductServiceMock();
            _controller = new CatalogController(_productService);
            _controller.Request = new HttpRequestMessage();
            _controller.Configuration = new HttpConfiguration();
        }

        
        [TestMethod]
        public void CatalogController_ShouldReturnAllProductsOfCatalog()
        {
            var testProducts = _productService.GetCatalogProducts() as List<CatalogModel>;

            var response = _controller.Get();
            List<CatalogModel> content = response.Content.ReadAsAsync<List<CatalogModel>>().Result;

            Assert.AreEqual(testProducts.Count, content.Count);
        }

    }
}
