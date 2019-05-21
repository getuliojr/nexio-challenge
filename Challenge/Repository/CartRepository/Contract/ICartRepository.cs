using Challenge.Entity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Repository.CartRepository.Contract
{
    public interface ICartRepository
    {
        void CreateCart(Cart cart);
        Cart GetCart(FilterDefinition<Cart> filter);
        void UpdateCart(Cart cart);
    }
}
