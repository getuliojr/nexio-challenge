using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge.Models.Sale
{
    public class AddProductOnSaleModel
    {
        public string ProductId { get; set; }
        public double SalePrice { get; set; }
        public DateTime Expires { get; set; }
    }
}