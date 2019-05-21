using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge.Models.Sale
{
    public class SaleProduct
    {
        public string SaleId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public double SalePrice { get; set; }
    }
}