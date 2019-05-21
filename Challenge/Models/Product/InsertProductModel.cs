using Challenge.Commons.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Challenge.Models.Product
{
    public class InsertProductModel
    {

        [Required]
        public CategoryEnum CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }

    }
}