using Challenge.Models.Catalog;
using Challenge.Services.ProductService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Challenge.Controllers
{
    public class CatalogController : BaseController
    {
        private readonly IProductService productService;

        public CatalogController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            var catalogProducts = productService.GetCatalogProducts();

            return Request.CreateResponse(HttpStatusCode.OK, catalogProducts);
        }
    }
}
