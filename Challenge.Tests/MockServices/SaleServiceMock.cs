using Challenge.Commons.Const;
using Challenge.Models.Catalog;
using Challenge.Models.Product;
using Challenge.Models.Sale;
using Challenge.Services.SaleService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge.MockServices.SaleServiceMock
{
    public class SaleServiceMock : ISaleService
    {
        private readonly List<SaleProduct> _mockSaleProducts;
        public SaleServiceMock()
        {
            _mockSaleProducts = new List<SaleProduct>();
            _mockSaleProducts.Add(new SaleProduct { SaleId = "1", ProductName = "Teste1", ProductPrice=50, SalePrice=25 });
            _mockSaleProducts.Add(new SaleProduct { SaleId = "2", ProductName = "Teste2", ProductPrice = 100, SalePrice = 50 });
            _mockSaleProducts.Add(new SaleProduct { SaleId = "3", ProductName = "Teste3", ProductPrice = 150, SalePrice = 70 });
            _mockSaleProducts.Add(new SaleProduct { SaleId = "4", ProductName = "Teste4", ProductPrice = 200, SalePrice = 150 });
        }

        public void AddProductOnSale(AddProductOnSaleModel model)
        {
            var newItem = new SaleProduct
            {
                SaleId = (_mockSaleProducts.Count + 1).ToString(),
                ProductName = model.ProductId,
                ProductPrice = model.SalePrice * 2,
                SalePrice = model.SalePrice,
            };

            _mockSaleProducts.Add(newItem);
        }
        public IEnumerable<SaleProduct> GetProductsOnSale()
        {
            return _mockSaleProducts;
        }
    }
}