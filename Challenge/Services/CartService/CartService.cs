using Challenge.Commons.Const;
using Challenge.Entity;
using Challenge.Models.Cart;
using Challenge.Models.Product;
using Challenge.Models.Sale;
using Challenge.Repository.CartRepository.Contract;
using Challenge.Repository.ProductRepository.Contract;
using Challenge.Repository.SaleRepository.Contract;
using Challenge.Services.CartService.Contract;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ICartRepository cartRepository;
        private readonly ISaleRepository saleRepository;
        private readonly IProductRepository productRepository;

        public CartService(ICartRepository cartRepository, IProductRepository productRepository, ISaleRepository saleRepository)
        {
            this.cartRepository = cartRepository;
            this.productRepository = productRepository;
            this.saleRepository = saleRepository;
        }

        public CartModel GetCartByUserId(string userId)
        {
            var filter = Builders<Cart>.Filter.Eq(x => x._idUser, ObjectId.Parse(userId));
            var productsOnSale = saleRepository.GetSales(Builders<Sale>.Filter.Gt(s => s.Expires, DateTime.Now));
            var cart = cartRepository.GetCart(filter);

            if (cart == null)
                CreateCartForUser(userId);

            cart = cartRepository.GetCart(filter);

            var cartResult = new CartModel
            {
                _id = cart._id.ToString(),
                Products = cart.Products.Select(x => new ProductModel
                {
                    Name = x.Name,
                    CategoryId = x.CategoryId,
                    Price = x.Price,
                    Description = x.Description,
                    _id = x._id.ToString(),
                    SalePrice = productsOnSale.Where(p => p._idProduct == x._id).FirstOrDefault()?.SalePrice,
                    SaleExpiresDate = productsOnSale.Where(p => p._idProduct == x._id).FirstOrDefault()?.Expires

                })
                
            };
            cartResult.Total = cartResult.Products.Select(p=> p.SalePrice ?? p.Price).Sum();
            return cartResult;
        }

        public void AddProductToCart(string cartId, string productId)
        {
            var filter = Builders<Cart>.Filter.Where(x => x._id == ObjectId.Parse(cartId));
            var filterProduct = Builders<Product>.Filter.Where(x => x._id == ObjectId.Parse(productId));

            var cart = cartRepository.GetCart(filter);
            if (cart == null)
                throw new Exception(ExceptionMessages.CartNotExist);

            var product = productRepository.GetProduct(filterProduct);
            if (product == null)
                throw new Exception(ExceptionMessages.ProductNotFound);

            cart.Products.Add(product);
            cartRepository.UpdateCart(cart);
        }

        public void RemoveProductFromCart(string cartId, string productId)
        {
            var filter = Builders<Cart>.Filter.Where(x => x._id == ObjectId.Parse(cartId));
            var cart = cartRepository.GetCart(filter);

            if (cart == null)
                throw new Exception(ExceptionMessages.CartNotExist);

            cart.Products = cart.Products.Where(x => x._id.ToString() != productId).ToList();
            cartRepository.UpdateCart(cart);
        }

        private void CreateCartForUser(string userId)
        {
            var cart = new Cart
            {
                _id = ObjectId.GenerateNewId(),
                _idUser = ObjectId.Parse(userId),
                Products = new List<Product>()
            };

            cartRepository.CreateCart(cart);
        }
    }
}