using Challenge.Commons.Exceptions;
using Challenge.Models.Product;
using Challenge.Services.ProductService.Contract;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Challenge.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }


        [HttpGet]
        public HttpResponseMessage Get()
        {
            var products = this.productService.GetProducts();
            return Request.CreateResponse(HttpStatusCode.OK, products);
        }

        [HttpGet]
        public HttpResponseMessage Get([FromUri] string id)
        {
            try
            {
                var product = this.productService.GetProductById(id);

                return Request.CreateResponse(HttpStatusCode.OK, product);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] InsertProductModel model)
        {
            if (!ModelState.IsValid)
                throw new InvalidModelException();

            var newProduct = this.productService.AddProduct(model);
            return Request.CreateResponse(HttpStatusCode.OK, newProduct);
        }
    }
}
