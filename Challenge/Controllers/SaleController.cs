using Challenge.Commons.Const;
using Challenge.Commons.Exceptions;
using Challenge.Models.Sale;
using Challenge.Services.SaleService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Challenge.Controllers
{
    public class SaleController : ApiController
    {
        private readonly ISaleService saleService;

        public SaleController(ISaleService saleService)
        {
            this.saleService = saleService;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            var saleProducts = saleService.GetProductsOnSale();
            return Request.CreateResponse(HttpStatusCode.OK, saleProducts);
        }

        [HttpPost]
        public HttpResponseMessage Post(AddProductOnSaleModel model)
        {
            if (!ModelState.IsValid)
                throw new InvalidModelException();

            saleService.AddProductOnSale(model);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
