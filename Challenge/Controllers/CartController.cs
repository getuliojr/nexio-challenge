using Challenge.Filters;
using Challenge.Models.Cart;
using Challenge.Services.CartService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Challenge.Controllers
{
    [AuthFilter]
    public class CartController : BaseController
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            var userInfo = GetUserInfo();
            var userCart = cartService.GetCartByUserId(userInfo.UserId);
            return Request.CreateResponse(HttpStatusCode.OK, userCart);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] ProductInCartModel model)
        {
            var userInfo = GetUserInfo();
            var userCart = cartService.GetCartByUserId(userInfo.UserId);

            cartService.AddProductToCart(userCart._id, model.ProductId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage Delete([FromBody] ProductInCartModel model)
        {
            var userInfo = GetUserInfo();
            var userCart = cartService.GetCartByUserId(userInfo.UserId);

            cartService.RemoveProductFromCart(userCart._id, model.ProductId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
