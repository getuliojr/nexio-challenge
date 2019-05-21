using Challenge.Commons.Const;
using Challenge.MockServices.ProductServiceMock;
using Challenge.Models.Cart;
using Challenge.Models.Product;
using Challenge.Services.CartService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Tests.MockServices
{
    public class CartServiceMock : ICartService
    {
        private Dictionary<string, CartModel> _mockCarts;
        private ProductServiceMock _mockProductService;

        public CartServiceMock()
        {
            _mockProductService = new ProductServiceMock();
            var mockProducts = _mockProductService.GetProducts();

            _mockCarts = new Dictionary<string, CartModel>()
            {
                { "user1", new CartModel { Products = mockProducts, Total = mockProducts.Count(), _id = "1" } },
                { "user2",  new CartModel { Products = mockProducts.Take(2), Total = mockProducts.Take(2).Count(), _id = "2" }}
            };
        }
        public void AddProductToCart(string cartId, string productId)
        {
            var userCart = _mockCarts.Where(x => x.Value._id == cartId).FirstOrDefault();
            var cart = userCart.Value;

            var product = this._mockProductService.GetProductById(productId);
            if (product == null)
                throw new Exception(ExceptionMessages.ProductNotFound);

            var products = cart.Products.ToList();
            products.Add(product);

            cart.Products = products;
            cart.Total = cart.Products.Count();

            _mockCarts[userCart.Key] = cart;
        }

        public CartModel GetCartByUserId(string userId)
        {
            _mockCarts.TryGetValue(userId, out var cart);
            if (cart == null)
            {
                cart = new CartModel
                {
                    _id = "Cart" + (_mockCarts.Count + 1),
                    Products = new List<ProductModel>(),
                    Total = 0
                };

                _mockCarts.Add(userId, cart);

                return cart;
            }

            return cart;
        }

        public void RemoveProductFromCart(string cartId, string productId)
        {
            var userCart = _mockCarts.Where(x => x.Value._id == cartId).FirstOrDefault();
            var cart = userCart.Value;

            cart.Products = cart.Products.Where(x => x._id != productId);
            cart.Total = cart.Products.Count();

            _mockCarts[userCart.Key] = cart;
        }
    }
}
