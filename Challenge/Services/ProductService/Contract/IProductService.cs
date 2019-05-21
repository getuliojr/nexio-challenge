using Challenge.Models.Catalog;
using Challenge.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Services.ProductService.Contract
{
    public interface IProductService
    {
        ProductModel GetProductById(string id);
        ProductModel AddProduct(InsertProductModel model);
        IEnumerable<ProductModel> GetProducts();
        IEnumerable<CatalogModel> GetCatalogProducts();
    }
}
