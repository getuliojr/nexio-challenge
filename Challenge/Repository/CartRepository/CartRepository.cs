using Challenge.Entity;
using Challenge.Repository.CartRepository.Contract;
using Challenge.Repository.Context;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge.Repository.CartRepository
{
    /// <summary>
    /// DataAccess to cart collection from mongodb.
    /// </summary>
    public class CartRepository : ICartRepository
    {
        private readonly IMongoCollection<Cart> cartCollection;

        /// <summary>
        /// Reference collection.
        /// </summary>
        /// <param name="context"></param>
        public CartRepository(IMongoContext context)
        {
            cartCollection = context.GetCollection<Cart>();
        }

        /// <summary>
        /// Insert a cart into mongodb collection.
        /// </summary>
        /// <param name="cart"></param>
        public void CreateCart(Cart cart)
        {
            cartCollection.InsertOne(cart);
        }

        /// <summary>
        /// Get cart reference from mongodb collection.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Cart GetCart(FilterDefinition<Cart> filter)
        {
            return cartCollection.Find(filter).FirstOrDefault();
        }

        /// <summary>
        /// Update cart into mongodb collection.
        /// </summary>
        /// <param name="cart"></param>
        public void UpdateCart(Cart cart)
        {
            var filter = Builders<Cart>.Filter.Eq(x => x._id, cart._id);
            cartCollection.ReplaceOne(filter, cart);
        }
    }
}