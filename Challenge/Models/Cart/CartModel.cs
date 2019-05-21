using Challenge.Models.Product;
using Challenge.Models.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge.Models.Cart
{
    public class CartModel
    {
        public string _id { get; set; }
        public IEnumerable<ProductModel> Products { get; set; }
        public double Total { get; set; }
    }
}