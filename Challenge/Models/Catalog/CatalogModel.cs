using Challenge.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge.Models.Catalog
{
    public class CatalogModel
    {
        public string CategoryName { get; set; }
        public IEnumerable<ProductModel> Products { get; set; }
    }
}