using Challenge.Controllers;
using Challenge.MockServices.SaleServiceMock;
using Challenge.Models.Sale;
using Challenge.Services.SaleService.Contract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Challenge.Tests
{
    [TestClass]
    public class SaleControllerTest
    {
        SaleController _controller;
        ISaleService _saleService;

        public SaleControllerTest()
        {
            _saleService = new SaleServiceMock();
            _controller = new SaleController(_saleService);
            _controller.Request = new HttpRequestMessage();
            _controller.Configuration = new HttpConfiguration();
        }

        
        [TestMethod]
        public void SaleController_ShouldReturnAllSales()
        {
            var salesProducts = _saleService.GetProductsOnSale() as List<SaleProduct>;

            var response = _controller.Get();
            List<SaleProduct> content = response.Content.ReadAsAsync<List<SaleProduct>>().Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(salesProducts.Count, content.Count);
        }

        public void SaleController_ShouldAddProductOnSale()
        {
            var newItem = new AddProductOnSaleModel
            {
                ProductId = "ProductId",
                Expires = System.DateTime.Now.AddDays(5),
                SalePrice = 35
            };

            var content = _controller.Post(newItem);

            List<SaleProduct> response = content.Content.ReadAsAsync<List<SaleProduct>>().Result;
            var sales = _saleService.GetProductsOnSale() as List<SaleProduct>;

            Assert.AreEqual(sales.Count, 5);
        }
    }
}
