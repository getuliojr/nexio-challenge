using Challenge.Commons.Helper;
using Challenge.Controllers;
using Challenge.Models.Cart;
using Challenge.Services.CartService.Contract;
using Challenge.Tests.MockServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Challenge.Tests
{
    [TestClass]
    public class CartControllerTest
    {
        CartController _controller;
        ICartService _cartService;

        public CartControllerTest()
        {
            _cartService = new CartServiceMock();
            _controller = new CartController(_cartService);
            _controller.Request = new HttpRequestMessage();
            _controller.Configuration = new HttpConfiguration();
        }

        [TestMethod]
        public void GetCartByUserId_ShouldCreateCartToANewUser()
        {
            var token = JwtHelper.CreateToken("user_test", "user123");

            _controller.Request.Headers.Add("Authorization", token);
            var response = _controller.Get();

            var cart = response.Content.ReadAsAsync<CartModel>().Result;

            Assert.IsNotNull(cart);
        }

        [TestMethod]
        public void GetCartByUserId_ShouldReturnACartOfAKnownUser()
        {
            var token = JwtHelper.CreateToken("user_test", "user1");

            _controller.Request.Headers.Add("Authorization", token);
            var response = _controller.Get();

            var cart = response.Content.ReadAsAsync<CartModel>().Result;

            Assert.IsTrue((cart.Products.Count() > 0));
        }

        [TestMethod]
        public void AddProductToCart_ShouldAddProductToCart()
        {
            var token = JwtHelper.CreateToken("user_test", "user1");

            _controller.Request.Headers.Add("Authorization", token);
            var response = _controller.Get();

            var cartBeforeAddProduct = response.Content.ReadAsAsync<CartModel>().Result;
            var totalBeforeAdd = cartBeforeAddProduct.Total;

            var productInCartModel = new ProductInCartModel
            {
                ProductId = "1"
            };

            response = _controller.Post(productInCartModel);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            response = _controller.Get();
            var cartAfterAddProduct = response.Content.ReadAsAsync<CartModel>().Result;

            Assert.AreEqual(cartAfterAddProduct.Total, totalBeforeAdd + 1);
        }

        [TestMethod]
        public void AddProductToCart_ShouldThrowExceptionWhenAddingAProductThatDoNotExists()
        {
            var token = JwtHelper.CreateToken("user_test", "user1");
            _controller.Request.Headers.Add("Authorization", token);

            var productInCartModel = new ProductInCartModel
            {
                ProductId = "909090"
            };

            Assert.ThrowsException<Exception>(() => { _controller.Post(productInCartModel); });
        }

        [TestMethod]
        public void RemoveProductFromCart_ShouldRemoveProductFromCart()
        {
            var token = JwtHelper.CreateToken("user_test", "user1");

            _controller.Request.Headers.Add("Authorization", token);
            var response = _controller.Get();

            var cartBeforeRemoveProduct = response.Content.ReadAsAsync<CartModel>().Result;
            var totalBeforeRemove = cartBeforeRemoveProduct.Total;

            var productInCartModel = new ProductInCartModel
            {
                ProductId = "1"
            };

            response = _controller.Delete(productInCartModel);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            response = _controller.Get();
            var cartAfterRemoveProduct = response.Content.ReadAsAsync<CartModel>().Result;

            Assert.AreEqual((cartAfterRemoveProduct.Total), totalBeforeRemove - 1);
        }
    }
}
