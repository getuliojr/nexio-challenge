using Challenge.Commons.Enum;
using Challenge.Models.Sale;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Challenge.Models.Product
{
    public class ProductModel
    {
        public string _id { get; set; }

        public string CategoryName
        {
            get
            {
                return Enum.GetName(typeof(CategoryEnum), this.CategoryId);
            }
        }

        [Required]
        public CategoryEnum CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }

        public double? SalePrice { get; set; }
        public DateTime? SaleExpiresDate { get; set; }


    }
}